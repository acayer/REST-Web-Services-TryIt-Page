using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace WordFilterService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        //global var for natural hazards service
        //
        //API key is outdated so this service will return invalid input
        public string apiKey = "OtbCBDSEJVvvtKQwsVYQMeiFQjXaYmOe";

        //global var for air quality service
        //
        //API key is outdated so this service will return invalid input
        public string apiKeyAir = "Y4mJqMvgzyzO6lih9Ks2X";
        public string secret = "MortPdqhlaI6yvIwwPFe6VJJQrJs2Q6LU3LEkcDI";

        //global var for word filter service
        //

        string[] stop_words = {
"a",
"about",
"above",
"after",
"again",
"against",
"all",
"am",
"an",
"and",
"any",
"are",
"aren't",
"as",
"at",
"be",
"because",
"been",
"before",
"being",
"below",
"between",
"both",
"but",
"by",
"can't",
"cannot",
"could",
"couldn't",
"did",
"didn't",
"do",
"does",
"doesn't",
"doing",
"don't",
"down",
"during",
"each",
"few",
"for",
"from",
"further",
"had",
"hadn't",
"has",
"hasn't",
"have",
"haven't",
"having",
"he",
"he'd",
"he'll",
"he's",
"her",
"here",
"here's",
"hers",
"herself",
"him",
"himself",
"his",
"how",
"how's",
"i",
"i'd",
"i'll",
"i'm",
"i've",
"if",
"in",
"into",
"is",
"isn't",
"it",
"it's",
"its",
"itself",
"let's",
"me",
"more",
"most",
"mustn't",
"my",
"myself",
"no",
"nor",
"not",
"of",
"off",
"on",
"once",
"only",
"or",
"other",
"ought",
"our",
"ours",
"ourselves",
"out",
"over",
"own",
"same",
"shan't",
"she",
"she'd",
"she'll",
"she's",
"should",
"shouldn't",
"so",
"some",
"such",
"than",
"that",
"that's",
"the",
"their",
"theirs",
"them",
"themselves",
"then",
"there",
"there's",
"these",
"they",
"they'd ",
"they'll",
"they're",
"they've",
"this",
"those",
"through",
"to",
"too",
"under",
"until",
"up",
"very",
"was",
"wasn't",
"we",
"we'd",
"we'll",
"we're",
"we've",
"were",
"weren't",
"what",
"what's",
"when",
"when's",
"where",
"where's",
"which",
"while",
"who",
"who's",
"whom",
"why",
"why's",
"with",
"won't",
"would",
"wouldn't",
"you",
"you'd",
"you'll",
"you're",
"you've",
"your",
"yours",
"yourself",
"yourselves",
        };

        //method implementations for word filter service
        //

        public string WordFilter(string str)
        {
            char[] punctuation = { ' ', '.', ',', ':', ';', '<', '>', '?', '"', '{', '}', '[', ']', '-', '+', '=', '/', '\'', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')' };
            string[] words_to_filter = str.Split(punctuation);
            string out_string = "";
            bool addWord = true;

            for(int i = 0; i < words_to_filter.Length; i++)
            {
                for(int j = 0; j < stop_words.Length; j++)
                {
                    if(words_to_filter[i].Equals(stop_words[j]))
                    {
                        //do not add word to out_string
                        addWord = false;
                    }
                    else
                    {
                        
                    }
                }
                if(addWord)
                {
                    if (i == 0)
                    {
                        out_string = out_string +  words_to_filter[i];
                    }
                    else
                    {
                        out_string = out_string + " " + words_to_filter[i];
                    }
                }
                addWord = true;
            }

            return out_string;
        }

        //method implementations for air quality service
        //

        public int GetAirQualityHeuristic(string str)
        {
            string url = @"https://api.aerisapi.com/airquality/" + str + "?client_id=" + apiKeyAir + "&client_secret=" + secret;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.Headers["token"] = apiKey;
            request.Accept = "application/json";
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();
            //return responsereader;
            RootObjectAir qualityObject = JsonConvert.DeserializeObject<RootObjectAir>(responsereader);

            Pollutants[] poll = qualityObject.response[0].periods[0].pollutants;
            bool med = false;
            bool bad = false;


            for (int i = 0; i < poll.Length; i++)
            {
                string check = poll[i].category.ToLower();
                if (check.Equals("good") || check.Equals("moderate"))
                {
                    //good air quality
                }
                else if (check.Equals("usg") || check.Equals("unhealthy"))
                {
                    med = true;//medium air quality
                }
                else if (check.Equals("very unhealthy") || check.Equals("hazardous"))
                {
                    bad = true;//bad air quality
                }

            }

            if (bad)
            {
                return 1;
            }
            else if (med)
            {
                return 2;
            }
            return 3;
            //return qualityObject;
            //Console.WriteLine("\nEnd of script reached\n");

        }

        //method implementations for natural hazards service
        //

        public double GetEMXT(string str)
        {
            //first get the data
            string url = @"https://www.ncdc.noaa.gov/cdo-web/api/v2/data?datasetid=gsom&locationid=ZIP:" + str + "&startdate=2021-01-01&enddate=2021-02-28&limit=999";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers["token"] = apiKey;
            request.Accept = "application/json";
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();
            RootObject hazardsObject = JsonConvert.DeserializeObject<RootObject>(responsereader);
            //now parse
            Results[] parse = hazardsObject.results;
            double[] values = new double[parse.Length];
            for (int i = 0; i < parse.Length; i++)
            {
                if (parse[i].datatype.Equals("EMXT"))
                {
                    values[i] = parse[i].value;
                }
            }
            double max = 0;
            int indexMax = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max)
                {
                    max = values[i];
                    indexMax = i;
                }
            }

            return max;
        }
        public double GetEMNT(string str)
        {
            //first get the data
            string url = @"https://www.ncdc.noaa.gov/cdo-web/api/v2/data?datasetid=gsom&locationid=ZIP:" + str + "&startdate=2021-01-01&enddate=2021-02-28&limit=999";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers["token"] = apiKey;
            request.Accept = "application/json";
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();
            RootObject hazardsObject = JsonConvert.DeserializeObject<RootObject>(responsereader);
            //now parse
            Results[] parse = hazardsObject.results;
            double[] values = new double[parse.Length];
            for (int i = 0; i < parse.Length; i++)
            {
                if (parse[i].datatype.Equals("EMNT"))
                {
                    values[0] = parse[i].value;
                }
            }
            double max = 0;
            int indexMax = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max)
                {
                    max = values[i];
                    indexMax = i;
                }
            }

            return max;
        }
        public double GetWSFG(string str)
        {
            //first get the data
            string url = @"https://www.ncdc.noaa.gov/cdo-web/api/v2/data?datasetid=gsom&locationid=ZIP:" + str + "&startdate=2021-01-01&enddate=2021-02-28&limit=999";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers["token"] = apiKey;
            request.Accept = "application/json";
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();
            RootObject hazardsObject = JsonConvert.DeserializeObject<RootObject>(responsereader);
            //now parse
            Results[] parse = hazardsObject.results;
            double[] values = new double[parse.Length];
            for (int i = 0; i < parse.Length; i++)
            {
                if (parse[i].datatype.Equals("WSFG"))
                {
                    values[i] = parse[i].value;
                }
            }
            double max = 0;
            int indexMax = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max)
                {
                    max = values[i];
                    indexMax = i;
                }
            }

            return max;
        }
        public double GetEMXP(string str)
        {
            //first get the data
            string url = @"https://www.ncdc.noaa.gov/cdo-web/api/v2/data?datasetid=gsom&locationid=ZIP:" + str + "&startdate=2021-01-01&enddate=2021-02-28&limit=999";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers["token"] = apiKey;
            request.Accept = "application/json";
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();
            RootObject hazardsObject = JsonConvert.DeserializeObject<RootObject>(responsereader);
            //now parse
            Results[] parse = hazardsObject.results;
            double[] values = new double[parse.Length];
            for (int i = 0; i < parse.Length; i++)
            {
                if (parse[i].datatype.Equals("EMXP"))
                {
                    values[i] = parse[i].value;
                }
            }
            double max = 0;
            int indexMax = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max)
                {
                    max = values[i];
                    indexMax = i;
                }
            }

            return max;
        }
        public double GetEMSN(string str)
        {
            //first get the data
            string url = @"https://www.ncdc.noaa.gov/cdo-web/api/v2/data?datasetid=gsom&locationid=ZIP:" + str + "&startdate=2021-01-01&enddate=2021-02-28&limit=999";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers["token"] = apiKey;
            request.Accept = "application/json";
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();
            RootObject hazardsObject = JsonConvert.DeserializeObject<RootObject>(responsereader);
            //now parse
            Results[] parse = hazardsObject.results;
            double[] values = new double[parse.Length];
            for (int i = 0; i < parse.Length; i++)
            {
                if (parse[i].datatype.Equals("EMSN"))
                {
                    values[i] = parse[i].value;
                }
            }

            double max = 0;
            int indexMax = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max)
                {
                    max = values[i];
                    indexMax = i;
                }
            }

            return max;
        }

    }
}
