using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Task_3
{
    public class DelayServer
    {
        public delegate void AnswerDelegate(string text);
        public event AnswerDelegate Answer;

        private string _answer;
        private Timer _timer;

        public void ReverseString(string text)
        {
            char[] chars = text.ToCharArray();
            Array.Reverse(chars);
            _answer = new string(chars);
            SetTimer();
        }
        public void CapitilizeString(string text)
        {
            char[] chars = text.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
                chars[i] = char.ToUpper(chars[i]);
            _answer = new string(chars);
            SetTimer();
        }
        public void SplitString(string text)
        {
            char[] chars = text.ToCharArray();
            List<string> list = new List<string>();
            foreach(char c in chars)
            {
                list.Add(c.ToString());
                list.Add(" ");
            }
            string result = string.Empty;
            foreach (string s in list) result += s;
            _answer = result;
            SetTimer();
        }
        private void SetTimer()
        {
            Random random = new Random();
            int interval = random.Next(5, 15) * 1000;
            _timer = new Timer(interval);
            _timer.AutoReset = false;
            _timer.Elapsed += ReturnAnswer;
            _timer.Enabled = true;

            _timer.Start();
        }
        private void ReturnAnswer(object sender, ElapsedEventArgs e)
        {
            Answer?.Invoke(_answer);
        }
    }
}
