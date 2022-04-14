﻿using System.Speech.Recognition;
using System.Text;

SpeechRecognitionEngine recognizer;
var playerNumbers = new string[] 
{ 
    "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", 
    "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", 
    "nineteen", "twenty", "twenty-one", "twenty-two", "twenty-three", "twenty-four", 
    "twenty-five", "twenty-six", "twenty-seven", "twenty-eight",
};

var plays = new string[] 
{ 
    "serve", "pass", "attack", "block", "set",
};

var hittingOptions = new string[]
{
    "fifty-one", "fifty-two", "super", "fourty-two", "two-two", "thirty-one", "two-one", 
    "tye", "wave", "jett", "thirty-two", "A-two", "red", "pink", "pipe", "b", "c", "dump", 
    "over-pass",
};

var passRating = new string[] 
{
    "three-pass", "two-pass", "one-pass", "error",
};

var hittingRating = new string[] 
{
    "continue", "error", "kill", "blocked",
};

var blockRating = new string[]
{
    "kill", "error"
};

var consoleCommands = new string[]
{
    "reset", "undo", "done"
};

var codes = new List<string>();
var sb = new StringBuilder();
var codeSb = new StringBuilder();

LoadSpeechRecognition();

Console.WriteLine("Listening...");

while (true)
{
    Console.ReadLine();
}




void LoadSpeechRecognition()
{
    recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));

    var pl = GetPlayLibrary();
    var gb = new GrammarBuilder(pl);
    var g = new Grammar(gb);
    recognizer.LoadGrammar(g);


    // Add a handler for the speech recognize event.
    recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(SpeechRecognized);

    //  Configure input to the speech recognizer.
    recognizer.SetInputToDefaultAudioDevice();

    // Start ssync, continuous speech recognition.
    recognizer.RecognizeAsync(RecognizeMode.Multiple);
}

[STAThreadAttribute]
void SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
{
    foreach (string identifier in e.Result.Text.Split(' '))
    {
        switch (identifier)
        {
            // Player Identifiers
            case "opponent":
                sb.Append("a");
                break;
            case "number":
                break;
            // Player Numbers Start
            case "zero":
                sb.Append("0");
                break;
            case "one":
                sb.Append("1");
                break;
            case "two":
                sb.Append("2");
                break;
            case "three":
                sb.Append("3");
                break;
            case "four":
                sb.Append("4");
                break;
            case "five":
                sb.Append("5");
                break;
            case "six":
                sb.Append("6");
                break;
            case "seven":
                sb.Append("7");
                break;
            case "eight":
                sb.Append("8");
                break;
            case "nine":
                sb.Append("9");
                break;
            case "ten":
                sb.Append("10");
                break;
            case "eleven":
                sb.Append("11");
                break;
            case "twelve":
                sb.Append("12");
                break;
            case "thirteen":
                sb.Append("13");
                break;
            case "fourteen":
                sb.Append("14");
                break;
            case "fifteen":
                sb.Append("15");
                break;
            case "sixteen":
                sb.Append("16");
                break;
            case "seventeen":
                sb.Append("17");
                break;
            case "eighteen":
                sb.Append("18");
                break;
            case "ninteen":
                sb.Append("19");
                break;
            case "twenty":
                sb.Append("20");
                break;
            case "twenty-one":
                sb.Append("21");
                break;
            case "twenty-two":
                sb.Append("22");
                break;
            case "twenty-three":
                sb.Append("23");
                break;
            case "twenty-four":
                sb.Append("24");
                break;
            case "twenty-five":
                sb.Append("25");
                break;
            case "twenty-six":
                sb.Append("26");
                break;
            case "twenty-seven":
                sb.Append("27");
                break;
            case "twenty-eight":
                sb.Append("28");
                break;

            // Player Actions
            case "serve":
                sb.Append("S ");
                AddCode();
                break;
            case "serve-ace":
                sb.Append("S# ");
                AddCode();
                break;
            case "serve-error":
                sb.Append("S=");
                AddCode();
                break;
            case "receive":
                sb.Append("R");
                break;
            case "attack":
                sb.Append("P");
                break;
            case "set":
                sb.Append("E");
                break;
            case "block":
                sb.Append("B");
                break;

            // Pass Ratings
            case "three-pass":
                sb.Append("# ");
                AddCode();
                break;
            case "two-pass":
                sb.Append("+ ");
                AddCode();
                break;
            case "one-pass":
                sb.Append("- ");
                AddCode();
                break;

            // Error rating
            case "error":
                sb.Append("= ");
                AddCode();
                break;

            // attack rating
            case "kill":
                sb.Append("# ");
                AddCode();
                break;
            case "ace":
                sb.Append("# ");
                AddCode();
                break;
            case "continue":
                sb.Append("+ ");
                AddCode();
                break;
            case "blocked":
                sb.Append("/ ");
                AddCode();
                break;

            // attack calls
            case "fifty-one":
                sb.Append("Q");
                break;
            case "fifty-two":
                sb.Append("W");
                break;
            case "super":
                sb.Append("E");
                break;
            case "fourty-two":
                sb.Append("R");
                break;
            case "two-two":
                sb.Append("T");
                break;
            case "thirty-one":
                sb.Append("A");
                break;
            case "thirty-two":
                sb.Append("Z");
                break;
            case "two-one":
                sb.Append("D");
                break;
            case "tye":
                sb.Append("F");
                break;
            case "wave":
                sb.Append("G");
                break;
            case "jett":
                sb.Append("H");
                break;
            case "A-2":
                sb.Append("X");
                break;
            case "red":
                sb.Append("C");
                break;
            case "pink":
                sb.Append("V");
                break;
            case "pipe":
                sb.Append("B");
                break;
            case "b":
                sb.Append("N");
                break;
            case "c":
                sb.Append("M");
                break;
            case "over-pass":
                sb.Append("O");
                break;

            case "dump":
                sb.Append("Y");
                break;

            case "done":
                // Has to copy something
                if(codes.Count > 0)
                {
                    GetCodeString();
                    sb.Clear();
                    codes.Clear();
                }
                else
                {
                    Console.WriteLine("Nothing to copy...");
                }
                break;

            case "reset":
                codes.Clear();
                Console.WriteLine("Starting coding over...");
                break;

            case "undo":
                // nothing to undo
                if (codes.Count == 0)
                {
                    Console.WriteLine("Nothing to undo...");
                }
                else
                {
                    Console.WriteLine("Removing newest command...");
                    codes.RemoveAt(codes.Count - 1);
                    foreach (var code in codes)
                    {
                        Console.WriteLine(code.ToString());
                    }
                }
                break;


            default:
                break;

        }
    }
    Console.WriteLine(sb.ToString());

}

void GetCodeString()
{
    foreach(var code in codes)
    {
        codeSb.Append(code.ToString());
    }
    Thread thread = new Thread(() => Clipboard.SetText(codeSb.ToString()));
    
    thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
    thread.Start();
    thread.Join();
    //Console.WriteLine(codeSb.ToString());
    Console.WriteLine("Code(s) copied to clipboard...");
    codeSb.Clear();
}

void AddCode()
{
    codes.Add(sb.ToString());
    foreach (var code in codes)
    {
        Console.Write(code.ToString());
    }
    sb.Clear();
}

Choices GetPlayLibrary()
{
    Choices options = new Choices();
    foreach (var command in consoleCommands)
    {
        options.Add(command);
    }
    foreach (var number in playerNumbers)
    {
        foreach(var play in plays)
        {
            if (play == "serve")
            {
                // Serve In
                options.Add($"number {number} serve");
                options.Add($"opponent number {number} serve");
                // Serve Ace
                options.Add($"number {number} serve-ace");
                options.Add($"opponent number {number} serve-ace");
                // Serve Error
                options.Add($"number {number} serve-error");
                options.Add($"opponent number {number} serve-error");
            }
            if (play == "pass")
            {
                foreach (var rating in passRating)
                {
                    options.Add($"number {number} receive {rating}");
                    options.Add($"opponent number {number} receive {rating}");
                }
                    
            }
            if (play == "attack")
            {
                foreach (var hittingCall in hittingOptions)
                {
                    foreach(var rating in hittingRating)
                    {
                            options.Add($"number {number} attack {hittingCall} {rating}");
                            options.Add($"opponent number {number} attack {hittingCall} {rating}");
                    }
                }
            }
            if (play == "block")
            {
                foreach(var rating in blockRating)
                {
                    options.Add($"number {number} block {rating}");
                    options.Add($"opponent number {number} block {rating}");
                }
            }
            if (play == "set")
            {
                options.Add($"number {number} set error");
                options.Add($"opponent number {number} set error");
            }
        }
    }
    return options;
        
}