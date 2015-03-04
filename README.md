# SwiftParser
C# Library to parse the SWIFT MT Financial Messages.

There are a number of tests that can be used to understand the usage of the library.

What's Available:

A great majority of the popular tags in a swift message are available (65%). I'll be working on the rest shortly.
Only parsing a swift message is available future versions will have building the message as well

Usage:

Grab a file and place it in a variable and then parse the message as below.

using (StreamReader sr = File.OpenText(FileName))
{
  str = sr.ReadToEnd();
}

SwiftMessage message = new SwiftMessage();
message.ParseSwiftMessage(str.Trim());

Now you have an object called message seperated in blocks

