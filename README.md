# Starter

How to check your work
To validate that your code satisfies the specified requirements, complete the following steps:

Use Visual Studio Code to build and run your app.
Note

You can exit the verification test before completing all of the verification steps if see a result that does not satisfy
the specification requirements. To force an exit from the running program, in the Terminal panel, press Ctrl-C. After
exiting the running app, complete the edits that you believe will address the issue you are working on, save your
updates to the Program.cs file, and then re-build and run your code.

The terminal command prompt should display as the starting point for the program

At the command prompt, enter 2 menu:

Output

Copy
Welcome to the Contoso PetFriends app. Your main menu options are:

1. List all of our current pet information
2. Display all dogs with a specified characteristic

Enter your selection number (or type Exit to exit the program)
2

Enter dog characteristics to search for separated by commas
At the command prompt, enter large, cream, golden to test when more than one search term matches the dog descriptions.
Verify that the Terminal panel updates with a message similar to the code output sample:

Output

Copy
Enter dog characteristics to search for separated by commas
large, cream, golden

Our dog Nickname: lola matches your search for cream
Our dog Nickname: lola matches your search for golden
Nickname: lola (ID #: d1)
Physical description: medium sized cream colored female golden retriever weighing about 45 pounds. housebroken.
Personality: loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.

Our dog Nickname: gus matches your search for golden
Our dog Nickname: gus matches your search for large
Nickname: gus (ID #: d2)
Physical description: large reddish-brown male golden retriever weighing about 85 pounds. housebroken.
Personality: loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give
doggy hugs.

Press the Enter key to continue
At the command prompt, press the enter key to continue to the main menu

At the command prompt, enter 2 menu:

Output

Copy
Welcome to the Contoso PetFriends app. Your main menu options are:

1. List all of our current pet information
2. Display all dogs with a specified characteristic

Enter your selection number (or type Exit to exit the program)
2

Enter dog characteristics to search for separated by commas

At the command prompt, enter big, grey, stripes to test when none of the search terms match dog descriptions. Verify
that the Terminal panel updates with a message similar to the code output samples:

Output

Copy
Enter dog characteristics to search for separated by commas
big, grey, stripes

None of our dogs are a match for: big, grey, stripes

Press the Enter key to continue
If you specified further restrictions for valid entries, run the appropriate test cases to verify your work.

Note

If your code meets the requirements you should be able to complete each step in order and see the expected results in a
single test pass. If you added additional restrictions, you may need to exit the application and then run a separate
test pass to complete your verification.

Congratulations if you succeeded in this challenge exercise!