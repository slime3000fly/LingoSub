using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using DeepL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using File = System.IO.File;
using System.Threading.Tasks;
using System.Collections.Generic;
using SRT;


namespace LingoSub
{
    public partial class Form3 : Form

    {
        public string file_input { get; private set; }

        public string file_output { get; private set; }

        public string authKey { get; private set; }
        public string lang { get; private set; }

        public string filepath = Application.StartupPath;
        public Form3()
        {
            InitializeComponent();
        }


       

        private void powrot_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Srt Files (*.srt)|*.srt";
            openFileDialog.DefaultExt = "srt";
            openFileDialog.AddExtension = true;
            openFileDialog.ShowDialog(this);
            file_input = openFileDialog.FileName;
            file.Text = openFileDialog.FileName;
        }

        private void openDestination_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Srt Files (*.srt)|*.srt";
            saveFileDialog.DefaultExt = "srt";
            saveFileDialog.AddExtension = true;
            saveFileDialog.ShowDialog(this);
            

            file_output = saveFileDialog.FileName;
            destination.Text = saveFileDialog.FileName;
        }

        private void translate_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(filepath + "\\info.txt");
            try
            {
                sw.WriteLine(file_input);
                sw.WriteLine(file_output);
                sw.Close();
            }
            catch (Exception ee)
            {
                Console.WriteLine("Exception: " + ee.Message);
            }


            srtkonwersja();
        }

        public async Task<string> tlumacz(string x)
        {
           
            if (File.Exists(filepath + "\\settings.txt"))
            {
                StreamReader streamReader = new StreamReader(filepath + "\\settings.txt");
                try
                {
                    lang = streamReader.ReadLine().ToString();
                    authKey = streamReader.ReadLine().ToString();
                    streamReader.Close();
                }
                catch (Exception ee)
                {
                    Console.WriteLine("Exception: " + ee.Message);
                    MessageBox.Show("wystapil blad");
                }
            }
            else
            {
                MessageBox.Show("blad zajrzyj do ustawien");
            }

            var translator = new Translator(authKey);

            var translatedText = await translator.TranslateTextAsync(
            x, null,
                lang);
            Console.WriteLine(translatedText.Text);
           return translatedText.Text;
        }

        async void srtkonwersja()
        {
            SRTFile instancja = new SRTFile(file.Text); // Create an instance of the SRTFile class by opening the SRT file
            var srt = new SRTFile(file.Text); // open srt file

            int subititles_number = srt.Subtitles.Count; // Get the number of subtitles in the SRT file

            // Iterate through each subtitle in the SRT file
            for (int i = 0; i < subititles_number; i++)
            {
                string tmp = "";
                string string_fragment = ""; // It is used to store a fragment of text that
                                             // has been carried over from the previous subtitle and is waiting to be combined with the next subtitle for translation purposes

                string text = srt.Subtitles[i].Text; // Get the text of the current subtitle

                List<string> splited_text = split_sentence(text);

                if (string_fragment.Length == 0)
                {
                    // Check if the text has been split into multiple sentences
                    if (splited_text.Count > 1)
                    {
                        string_fragment = splited_text[splited_text.Count - 1] + "~"; // adding a special character to the last sentence in a split text to know where to split the translated sentence
                        tmp = "";
                        for (int d = 0; d < splited_text.Count; d++)
                        {
                            if (d == splited_text.Count - 1)
                            {
                                break;
                            }
                            tmp = tmp + splited_text[d];
                            //TODO: tu bedzie tlumaczone wstaw krzysiu tu funkcje tlumaczenia
                            //TODO: srt.Subtitles[i].Text = tlumacz(tmp);
                            srt.Subtitles[i].Text = await tlumacz(tmp);
                        }
                    }
                    else
                    {
                        //TODO: tu bedzie tlumaczone wstaw krzysiu tu funkcje tlumaczenia
                        //TODO: srt.Subtitles[i].Text = tlumacz(text);
                        srt.Subtitles[i].Text = await tlumacz(text);
                    }
                }
                else
                {
                    string tmp_text = string_fragment + text;
                    tmp_text = ""; //TODO: tu bedzie tlumaczone wstaw krzysiu tu funkcje tlumaczenia
                                   //TODO: srt.Subtitles[i].Text = tlumacz(tpm_text);

                    srt.Subtitles[i].Text = await tlumacz(tmp_text);
                    char wqtert = '~';


                    List<string> string_fragment_2 = new List<string>(tmp_text.Split(wqtert)); // split senetce in place where is special character 
                    string_fragment_2[0] = string_fragment_2[0].TrimStart();
                    if (string_fragment_2[0].Length != 1 && i != 1)
                    {
                        srt.Subtitles[i - 1].Text = srt.Subtitles[i - 1].Text + string_fragment_2[0];
                    }
                    else
                    {
                        srt.Subtitles[i].Text = string_fragment_2[0] + " " + string_fragment_2[1];
                    }

                    //clear variable
                    string_fragment = "";
                    string_fragment_2.Clear();
                }
            }

            srt.WriteToFile(destination.Text);
        }

        // Check if a character is a sentence-ending character
        static bool is_sentence_ending(char character)
        {
            // Checks if the given character is a sentence-ending character.

            List<char> sentenceEndings = new List<char> { '?', '!', '.' };
            return sentenceEndings.Contains(character);
        }

        /*
        Splits a given text into sentences based on sentence-ending characters.
        Args:
        text (str): The input text to be split into sentences.
        Returns:
        list: A list of sentences extracted from the input text.
        */
        static List<string> split_sentence(string text)
        {
            List<string> sentences = new List<string>();

            int skip = 0;
            int remo = 0; // variable to see how many cell was delet

            foreach (char character in text)
            {
                if (skip < remo)
                {
                    /*
                    This condition had to be created because the split method works in a way that generates consecutive cells
                    despite the fact that they are theoretically removed.
                    This occurs only in the case of character repetition, e.g., "...".
                    */
                    skip++;
                    continue;
                }
                else
                {
                    remo = 0;
                    skip = 0;
                }


                // split sentece if it is ending
                if (is_sentence_ending(character))
                {
                    List<string> tmp = new List<string>(text.Split(character));

                    tmp[0] = tmp[0] + character;

                    int last_elemnet = tmp.Count - 1;
                    if (tmp[last_elemnet].Length < 1)
                    {
                        /*
                        The condition was necessary due to the way the split function works. 
                        In cases such as "Co??" where you want to split the string based on the "?" character, 
                        it creates three segments. Since you've earlier added a character to the first cell of the list based 
                        on which the division occurs, the end result becomes "Co???" with an extra segment. 
                        That's why removing the last element from the list is needed.
                        */
                        tmp.RemoveAt(last_elemnet);
                    }

                    // delete empty cell in string
                    if (tmp.Count > 2)
                    {
                        for (int i = 0; i < tmp.Count + remo; i++)
                        {
                            if (string.IsNullOrEmpty(tmp[i - remo]))
                            {
                                if (i != 0)
                                {
                                    tmp[i - remo] = character.ToString();
                                    tmp[i - 1 - remo] = tmp[i - 1 - remo] + tmp[i - remo];
                                    tmp.RemoveAt(i - remo);
                                    remo++;
                                    // skip = 0;
                                }
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(tmp[0]))
                    {
                        sentences.Add(tmp[0]);
                        text = text.Replace(tmp[0], "");
                    }


                }
            }

            // Adding a string to the previous cell in the list
            // 'sentences' if its length is equal to 1. This is necessary
            // because if we have "..." it splits into 3 separate sentences.

            int remover = 0; // variable to see how many cell was delet

            for (int i = 0; i < sentences.Count + remover; i++)
            {
                int acutal_count = i - remover;
                if (sentences[acutal_count].Length == 1)
                {
                    if (acutal_count != 0)
                    {
                        sentences[acutal_count - 1] = sentences[acutal_count - 1] + sentences[acutal_count];
                        sentences.RemoveAt(acutal_count);
                        remover++;
                    }
                }
            }

            // check if last element is empty
            // if not add to sentences
            // if (!string.IsNullOrEmpty(tmp[tmp.Length - 1]) && tmp[tmp.Length - 1].Length > 1)
            // {
            //     sentences.Add(tmp[tmp.Length - 1]);
            // }

            return sentences;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
