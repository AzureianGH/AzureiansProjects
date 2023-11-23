using System;
using System.Collections.Generic;
using System.Linq;

namespace Ratings
{
    public class ProblemSet
    {
        public static double Average(List<double> numbers)
        {
            if (numbers.Count == 0)
            {
                return 0.0;
            }

            double sum = 0;
            double total = 0;

            foreach (double number in numbers)
            {
                sum += number;
                total += 1;
            }

            return sum / total;
        }

        public static int SumOfDigits(int num)
        {
            num = Math.Abs(num);
            int sum = 0;

            while (num > 0)
            {
                int val = num % 10;
                sum += val;
                num /= 10;
            }

            return sum;
        }

        public static string BestKey(Dictionary<string, int> val)
        {
            string bestVal = "";
            int xval = int.MinValue;

            foreach (var entry in val)
            {
                if (entry.Value > xval)
                {
                    xval = entry.Value;
                    bestVal = entry.Key;
                }
            }

            return bestVal;
        }
    }
    public class Song
    {
        public string songtitle = "";
        public string songartist = "";
        public string songID = "";
        public Song(string _songtitle, string _songartist, string _songID) 
        {
            songtitle = _songtitle;
            songartist = _songartist;
            songID = _songID;
        }
        public string GetTitle()
        {
            return songtitle;
        }
        public void SetTitle(string _songtitle)
        {
            songtitle = _songtitle;
        }
        public string GetArtist()
        {
            return songartist;
        }
        public void SetArtist(string _songartist)
        { 
            songartist = _songartist; 
        }
        public string GetSongID()
        {
            return songID;
        }
        public void SetSongID(string _songid)
        {
            songID = _songid;
        }
    }
    public class Rating
    {
        public string raterID;
        public int rating;

        public Rating(string _raterID, int _rating)
        {
            raterID = _raterID;
            if (_rating <= 5)
            {
                rating = _rating;
            }
            else
            {
                rating = -1;
            }
        }
        public string GetReviewerID()
        {
            return raterID;
        }
        public void SetReviewerID(string _raterID)
        {
            raterID = _raterID;
        }
        public int GetRating()
        {
            return rating;
        }
        public void setRating(int _rating)
        {
            if (rating <= 5)
            {
                rating = _rating;
            }
            else
            {
                rating = -1;
            }
        }
    }
    public class Reviewer
    {
        public string reviewerID = "";
        public Reviewer(string _reviewerID)
        {
            reviewerID = _reviewerID;
        }
        public string GetReviewerID()
        {
            return reviewerID;
        }
        public void SetReviewerID(string _reviewerID)
        { 
            reviewerID = _reviewerID;
        }
        public Rating RateSong(int _rating)
        {
            return new(reviewerID, _rating);
        }
    }
}
