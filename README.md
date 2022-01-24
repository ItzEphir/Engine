# Engine project for SFML.net#

## There is some useful stuff for simple programming on SFML.net with c\#. ##

+ Buttons
+ Some useful functions with Vector2f and printing on the window
+ Interface IDrawable

### Buttons ###
U have 4 types:
+ Classic
+ Active
+ Check
+ Active and Check

#### Classic Buttons ####

This button works if it was pressed. You can make the event what will happen if the button is pressed or aimed.
Or you can just ask it, call:

  button = new ClassicButton(parametres); \n
  Console.WriteLine(button.ButtonPressed); \n
  Console.WriteLine(button.ButtonAimed); \n

#### Active Buttons ####

This is the classic buttons but it changes the color if was aimed.

#### Check Buttons ####

These buttons work if the button was released.
So, ButtonEventPressed will be done if the button is released.
And ButtonPressed will be true if the button is released.

#### Active Check Buttons ####

These buttons work if the button was released and they change their color if aimed.


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
