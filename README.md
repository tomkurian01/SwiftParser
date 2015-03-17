# SwiftParser
C# Library to parse the SWIFT MT Financial Messages.

There are a number of tests that can be used to understand the usage of the library.

##What's Available:

1. A great majority of the popular tags in a swift message are available (65%). I'll be working on the rest shortly.
2. Parsing a Swift message tags into a collection of type ITag.
3. A Number of tests are available with sample messages. (You just have to change the path on the messages once you download)

## Usage:

### Grab any file and then send it to a stream.

using (StreamReader sr = File.OpenText(FileName))
{
  str = sr.ReadToEnd();
}

### Then parse the message

SwiftMessage message = new SwiftMessage();
message.ParseSwiftMessage(str.Trim());

Now you have an object called message seperated in blocks

