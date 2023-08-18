# LazyBot
This repository is a culmination of updates, tagged by build number, from the [LazyBot thread](https://www.ownedcore.com/forums/world-of-warcraft/world-of-warcraft-bots-programs/wow-bots-questions-requests/344596-lazybot-support-thread-q-requests-updates.html).

The initial set of commits are a copy/paste of the sources. I've begun work on refactoring the Pointers.cs file to use an interface, but that's not checked in yet. The migration to an interface allows me to provide a set of pointers per build number and load them based on the build of the selected WoW process file version.
