using System.Speech.Recognition;
using System.Text;

SpeechRecognitionEngine recognizer;


var codes = new List<string>();
var sb = new StringBuilder();
var numbers = new List<string>();

var playerNumbers = new List<string>
{
    "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
    "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen",
    "nineteen", "twenty", "twenty-one", "twenty-two", "twenty-three", "twenty-four",
    "twenty-five", "twenty-six", "twenty-seven", "twenty-eight", "twenty-nine", "thirty",
};

var plays = new List<string>
{
    "serve", "pass", "attack", "block", "set",
};

var hittingOptions = new List<string>
{
    "fifty-one", "fifty-two", "super", "fourty-two", "two-two", "dump", "over-pass", "thirty-one", "eleven", "twenty-one", 
    "tye", "wave", "jett", "thirty-two", "A-two", "red", "pink", "pipe", "b", "c",
};

var passRating = new List<string>
{
    "A-pass", "B-pass", "C-pass", "error",
    "Perfect-pass", "Three-pass", "Two-pass", "One-pass",
};

var hittingRating = new List<string>
{
    "continue", "error", "kill", "blocked",
};

var blockRating = new List<string>
{
    "kill", "error"
};

var consoleCommands = new List<string>
{
    "reset", "undo", "done"
};


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
    recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(SpeechRecognized!);

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
                sb.Append(";");
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
            case "twenty-nine":
                sb.Append("29");
                break;
            case "thirty":
                sb.Append("30");
                break;

            // Player Actions
            case "serve":
                sb.Append("s.");
                PrintCodeString();
                break;
            case "serve-ace":
                sb.Append("s# ");
                PrintCodeString();
                break;
            case "serve-error":
                sb.Append("s= ");
                PrintCodeString();
                break;
            case "receive":
                sb.Append("r");
                break;
            case "attack":
                sb.Append("p");
                break;
            case "set":
                sb.Append("e");
                break;
            case "block":
                sb.Append("b");
                break;

            // Pass Ratings
            case "A-pass":
            case "Perfect-pass":
            case "Three-pass":
                sb.Append("# ");
                PrintCodeString();
                break;
            case "B-pass":
            case "Two-pass":
                sb.Append("{+} ");
                PrintCodeString();
                break;
            case "C-pass":
            case "One-pass":
                sb.Append("- ");
                PrintCodeString();
                break;

            // Error rating
            case "error":
                sb.Append("= ");
                PrintCodeString();
                break;

            // attack rating
            case "kill":
                sb.Append("# ");
                PrintCodeString();
                break;
            case "ace":
                sb.Append("# ");
                PrintCodeString();
                break;
            case "continue":
                sb.Append("{+} ");
                PrintCodeString();
                break;
            case "blocked":
                sb.Append("/ ");
                PrintCodeString();
                break;
            /// OverLaps :(
            case "eleven":
                if (sb.ToString().EndsWith("p"))
                {
                    sb.Append("s");
                }
                else
                {
                    sb.Append("11");
                }
                break;
            case "twenty-one":
                if (sb.ToString().EndsWith("p"))
                {
                    sb.Append("d");
                }
                else
                {
                    sb.Append("21");
                }
                break;
            case "twenty-two":
                if (sb.ToString().EndsWith("p"))
                {
                    sb.Append("t");
                }
                else
                {
                    sb.Append("22");
                }
                break;
            case "fifty-one":
                sb.Append("q");
                break;
            case "fifty-two":
                sb.Append("w");
                break;
            case "super":
                sb.Append("e");
                break;
            case "fourty-two":
                sb.Append("r");
                break;  
            case "thirty-one":
                sb.Append("q");
                break;
            case "thirty-two":
                sb.Append("z");
                break;
            case "tye":
                sb.Append("f");
                break;
            case "wave":
                sb.Append("g");
                break;
            case "jett":
                sb.Append("h");
                break;
            case "A-2":
                sb.Append("x");
                break;
            case "red":
                sb.Append("c");
                break;
            case "pink":
                sb.Append("v");
                break;
            case "pipe":
                sb.Append("b");
                break;
            case "b":
                sb.Append("n");
                break;
            case "c":
                sb.Append("m");
                break;
            case "over-pass":
                sb.Append("o");
                break;
            case "dump":
                sb.Append("y");
                break;

/* Need Better functionality for this, re-add later.

            case "done":
                // Has to copy something
                if(codes.Count > 0)
                {
                    sb.Clear();
                    codes.Clear();
                    Console.WriteLine("Ready for next play...");
                }
                else
                {
                    Console.WriteLine("Listening...");
                }
                break;

            case "reset":
                RestartCodeString();
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
                    UndoCodeString();
                    codes.RemoveAt(codes.Count - 1);
                }
                break;
*/

            default:
                break;

        }
    }
}

void UndoCodeString()
{
    foreach(var character in codes.Last())
    {
        SendKeys.SendWait("{BACKSPACE}");
    }
}

void RestartCodeString()
{
    foreach(var code in codes)
    {
        foreach(var character in code)
        {
            SendKeys.SendWait("{BACKSPACE}");
        }
    }
    codes.Clear();
    Console.WriteLine("Starting coding over...");
}

void PrintCodeString()
{
    codes.Add(sb.ToString());
    SendKeys.SendWait(codes.Last());
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