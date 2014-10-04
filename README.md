Intro
=====
I wrote this little piece of code when once again the Windows search was not delivering (after searching for an eternity) a single result for a filename I was searching for even though I had at least one file with that name right in front of me in an explorer instance.

From the command line you can read in every filename that you have on harddiscs via

```
locate -update
```

That might take several minutes (and on an average computer between 100 and 200 megabytes of space) and will write every filename into a file called "locate.db" which will be located in the path of the exe-file. You will see some "Access to the path [xxx] is denied"-messages, depending on the user account with which you are executing the program. After "locate.db" is created you can search for files via

```
locate [searchterm]
```

The search is case-insensitive. That's it. You might want to make sure that the program is on your path so you can use it from everywhere.


License
=======

The MIT License (MIT)

Copyright (c) 2014 Joachim F. Rohde

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.