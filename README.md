First unity project playing around with a soccer simulation of some sort

Using Unity 2020.1.4f1

Local Testing
=============
From the Build directory, start a server: `python -m http.server --cgi 8360`
Then access the server via: `http://localhost:8360/index.html`

Release
=======
`butler push Builds/SoccerDemo.zip drawacard/SoccerDemo:webgl-beta`
