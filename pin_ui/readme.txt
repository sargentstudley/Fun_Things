Installation
-Install NPM
  if you're on Windows, you have to install npm for windows.  Use the installer trust me.
  Restart VSCode (so you get the latest path updates), open a terminal (control + tilde)
    npm install 12.14.1 ((I probably just used "stable", but it ended up being 12.14.1))
    npm use 12.14.1
    npm install -g @vue/cli ((strictly speaking, this may not be necessary unless you're creating projects, but it doesn't hurt.))
  verify your installation by typing running "vue ui" on the command line

-Add development extensions
  eslint (dbaeumer.vscode-eslint)
  prettier (esbenp.prettier-vscode)
  vetur (octref.vetur)

-Set up VSCode preferences
  settings are secretly a giant built in json file and when you modify them, you create your own personal preferences json file.
  The change to vetur validation just shuts off linting so that we can use eslint to do that, avoiding conflict between the two.
  The tweaks to eslint will automatically validate and autofix errors in Vue specific code, general html, and javascript.
  Edit your settings.json to have the following:
    "vetur.validation.template": false,
    "eslint.validate": [
        "vue",
        "html",
        "javascript"
    ],
    "editor.formatOnSave": true,

-Running the project
  We could use yarn and it's super spiffy, but since we're already using npm, we're configured to launch that way.
  To launch a locally hosted instance of the site for debugging and testing:
    npm run serve
  To build for production:
    npm run build
  See the generated README.md in the site folder for more commands.
