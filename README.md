# JSON-Covid-Dashoard
C# Windows Forms Covid Metrics Dashboard using a JSON API

In practical terms, the architecture used is the MVC pattern, that is, the division of the application into layers, a user interface called View, one for logical data manipulation called Model, and a third layer of application flow called Controller.

The programming language adopted is C# (Sharp) using Windows Forms. Json.NET API is used. The delegate event model is used in development as well as error handling uses an exception modeling.

The program is to represent the statistical data on the evolution of COVID-19 (SARS-CoV-2) in an easy-to-view panel, and with the data that most interest to know about the evolution of the pandemic. To build the application, the API as builted in Json.NET 4.1.2, to handle the data that Web API(s) provide about covid as:

• https://covid19-api.vost.pt;

• https://api.covid19api.com;

• https://covidtracking.com/data/api.

With the data obtained from the Web API(s), such data will be processed according to what the user chooses/intends. The indicative panel also intends to present a set of filters, so that it can help the user according to his desire to know the reality of the pandemic world.
