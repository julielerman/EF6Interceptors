EF6Interceptors
===============

[work in progress] Exploring how to break up trace from db init and migrations vs trace from actual application calls

currently I'm identifying using keywords  that would be in the commandtext (e.g. "create database" "__migrationHistory").

But that is not sustainable. I'm also exploring using enums.
