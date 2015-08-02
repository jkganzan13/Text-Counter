# Word-Counter

This is a C# program that parses a text file and produces the following information:

-The number of sentences in the text

-The number of words in the text

-The sentence with the most words

-The most frequently used word in the text

-The 3rd Longest word in the text

This program treats a series of strings that ends in a ".", "?" and "!" and followed by a space and capital letter as a sentence. This treats abbreviations or decimals (e.g. M.V.P. or 1.52) as words and counts the characters excluding "." 
However, at the moment, the program treats honorifics (e.g. Mr.) as a full sentence if it is followed by a space and capital letter (e.g. Mr. Jones).  

<h3>Suggestions for Further Development:</h3>

-Add support for honorifics (e.g. Mr., Ms., Mrs., etc.). This should be treated as a single word and not end of sentence.

-Add support for time (e.g. 3:00). This should be treated as a word.

