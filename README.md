# Engine project for SFML.net#

## There is some useful stuff for simple programming on SFML.net with c\#. ##

+ Buttons
+ Some useful functions with Vector2f and printing on the window
+ Interface IDrawable

### Buttons ###
U have 4 types:
+ Classic
+ Active

#### Classic Buttons ####

This button works if it was pressed. You can make the event what will happen if the button is pressed, aimed or released.
Or you can just ask it, call:

  ClassicButton button = new ClassicButton(parametres);
  Console.WriteLine(button.ButtonPressed);
  Console.WriteLine(button.ButtonAimed);
  Console.WriteLine(button.ButtonReleased);

#### Active Buttons ####

This is the classic buttons but it changes the color if was aimed.


### Vector2f and printing functions ###

+ PrintText() function
+ Distance() function
+ Normalise() function
+ Load() function
+ Save() function
+ Rectangle() function
+ NormalFloat() function

#### PrintText ####

It prints the text to the window (RenderWindow)
It has some parametres:
+ RenderWindow rw - the window
+ string message - text to the screen
+ Vector2f coords - coordinates of the text
+ uint size - font size
+ Color color - color of the text
+ Font font - font of the text
+ uint mode - this is centralizing of the text.
  1. 0 means right
  2. 1 means center
  3. 2 means left

You can call it:

  PrintText(rw, "Example", rw.Size / 2, 12, Color.White, Game.Font, 1)

#### Distance ####
It counts the distance from one point to another.
You can call it:

  Vector2f a = new Vector2f(100, 100);
  Vector2f b = new Vector2f(300, 300);
  float length = a.Distance(b);

#### Normalize ####
It makes a Vector2f what disctance is 1 and it is directed to the same side as original line of two Vectors.
You can call it:

  Vector2f a = new Vector2f(100, 100);
  Vector2f b = new Vector2f(200, 200);
  Vector2f direction = a.Normalise(b);

#### Load ####
It returns string from file.
You can call it:

  string info = Load("files/save.txt");

#### Save ####
It saves string to the file.
You can call it:

  string info = "I should be changed";
  Save("files/save.txt", info);

#### Rectangle ####
It makes a rectangle on the coords with your size and color.
You can call it:

  RenderWindow rw = new RenderWindow(vm, "Example");
  Rectangle(rw, rw.Size / 2, new Vector2f(100, 100), Color.White);

#### NormalFloat ####
It makes a float to aright number.
You can call it:

  float a = 3.0f;
  float b = 4.0f;
  float result = (a + b).NormalFloat(1f);
