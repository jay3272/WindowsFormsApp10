using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;

namespace WindowsFormsApp10
{
    public partial class Form1 : Form
    {
        #region 宣告

        //方法1
        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer Sarah = new SpeechSynthesizer();
        SpeechRecognitionEngine startlistening = new SpeechRecognitionEngine();
        Random rnd = new Random();
        int RecTimeOut = 0;
        DateTime TimeNow = DateTime.Now;

        //方法2
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();



        #endregion


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"DefaultCommands.txt")))));
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            _recognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(_recognizer_SpeechRecognized);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);

            startlistening.SetInputToDefaultAudioDevice();
            startlistening.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"DefaultCommands.txt")))));
            startlistening.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(startlistening_SpeechRecognized);

        }

        #region 方法1


        /// <summary>
        /// 開始聆聽語音辨識事件。
        /// </summary>
        /// <param name="sender">sender。</param>
        /// <param name="e">SpeechRecognizedEventArgs。</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private void startlistening_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;

            if (speech == "Wake up")
            {
                startlistening.RecognizeAsyncCancel();
                Sarah.SpeakAsync("Yes I am here");
                _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }

        }

        /// <summary>
        /// 檢測聆聽語音辨識事件。
        /// </summary>
        /// <param name="sender">。</param>
        /// <param name="e">。</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private void _recognizer_SpeechRecognized(object sender, SpeechDetectedEventArgs e)
        {
            RecTimeOut = 0;
        }

        /// <summary>
        /// 語音辨識事件。
        /// </summary>
        /// <param name="sender">。</param>
        /// <param name="e">。</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            int ranNum;
            string speech = e.Result.Text;

            switch (speech)
            {
                case "Hello":
                    Sarah.SpeakAsync("Hello, I am here");
                    break;
                case "How are you":
                    Sarah.SpeakAsync("I am fine");
                    break;
                case "What time is it":
                    Sarah.SpeakAsync(DateTime.Now.ToString("h mm tt"));
                    break;
                case "Stop talking":
                    Sarah.SpeakAsyncCancelAll();
                    ranNum = rnd.Next(1);
                    if (ranNum == 1)
                    {
                        Sarah.SpeakAsync("Yes sir");
                    }
                    if (ranNum == 2)
                    {
                        Sarah.SpeakAsync("I am sorry i will be quiet");
                    }
                    break;
                case "Stop Listening":
                    Sarah.SpeakAsync("if you need me just ask");
                    _recognizer.RecognizeAsyncCancel();
                    startlistening.RecognizeAsync(RecognizeMode.Multiple);
                    break;
                case "Show Commands":
                    string[] commands = (File.ReadAllLines(@"DefaultCommands.txt"));
                    LstCommands.Items.Clear();
                    LstCommands.SelectionMode = SelectionMode.None;
                    LstCommands.Visible = true;
                    foreach (string command in commands)
                    {
                        LstCommands.Items.Add(command);
                    }
                    break;
                case "Hide Commands":
                    LstCommands.Visible = false;
                    break;
                default:
                    Sarah.SpeakAsync(speech);
                    LstCommands.Items.Add(speech);
                    break;


            }

        }

        /// <summary>
        /// 定時監聽。
        /// </summary>
        /// <param name="sender">。</param>
        /// <param name="e">。</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private void TmrSpeaking_Tick(object sender, EventArgs e)
        {
            if (RecTimeOut == 10)
            {
                _recognizer.RecognizeAsyncCancel();
            }
            else if (RecTimeOut == 11)
            {
                TmrSpeaking.Stop();
                startlistening.RecognizeAsync(RecognizeMode.Multiple);
                RecTimeOut = 0;
            }
        }



        #endregion

        #region 方法2

        private void btn_start_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "start listening..." + "\n";
            method2();
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
            btn_start.Enabled = false;
            btn_Stop.Enabled = true;
        }

        /// <summary>
        /// method2。
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private void method2()
        {
            Choices commands = new Choices();
            commands.Add(new string[] { "Hi", "Say Hello", "Print my name" });
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);

            recEngine.LoadGrammarAsync(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += recEngine_SpeechRecognized;
            
        }

        private void recEngine_SpeechRecognized(object sender,SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "Hi":
                    richTextBox1.Text += "Hello" + "\n";
                    break;
                case "Say Hello":
                    richTextBox1.Text += "Hello, How are you?" + "\n";
                    break;
                case "Print my name":
                    richTextBox1.Text += "Jay" + "\n";
                    break;
                default:
                    richTextBox1.Text += e.Result.Text + "\n";
                    break;
            }

        }


        private void btn_Stop_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "stop listening!" + "\n";
            recEngine.RecognizeAsyncStop();
            btn_start.Enabled = true;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        #endregion

    }
}
