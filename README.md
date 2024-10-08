# TT International Coding Test

## Test Parameters

A researcher in the risk department requires you to design a report where you display the ratings associated with a set of instruments. The ratings consist of Moody's ratings for Bonds and External Analyst ratings for equities. 
The researcher wants to see the ISIN, SEDOL, instrument name, instrument type, base currency, moody's rating and analyst rating in the report. If a rating is not available, the report should display 'Not available' in the corresponding report column.

All datasets are available via REST API, and they can be fetched from the following URLs:

1. Instruments: https://mocki.io/v1/5c913cd3-77b2-43b7-9c74-0982e6174298
2. Moody's ratings: https://mocki.io/v1/11ab88f0-0a9a-44ad-ac40-334005fc5117
3. External Analyst ratings: https://mocki.io/v1/1cf057a5-e4c7-4cd3-9701-fbf29d379a39

Please devise a solution to build the researcher's report. You can use C#, Python, Javascript or a mix of these for your solution.

## Assumptions and Direction

The parameters of this coding test were very loose, so I made some assumptions that I will explain here.

1. I am a big advocate of using the SOLID principles and this solution aims to adhere to these principles. However, there are a few things I did add in here, mainly dependency inversion (ie. dependency injection) as I thought it might seem like over-engineering. I have tried however to stick the Single Responsibility and Open/Close principles as close as possible.

1. Given there was no direction on how the output should look, the report that is generated is in CSV form, however, there is the ability to implement a different type of report using the IReport interface.

1. I wasn't sure how this solution was to fit into the wider use case, so I have given two options to view the output: A console app that outputs to the screen and a CSV file in the `Debug` directory of the solution (please set this as start-up project if you wish to inspect) and I've also created an API endpoint that can be used to inspect the report using the Swagger endpoint (please set the startup project to the API project to verify this).

1. I have added several unit tests to indicate the type of tests that I would hope for in a solution like this. I appreciate that many would argue for the use of the red, green, refactor approach, but given my short time on this code base, I forgo this opportunity this time around. Also, I haven't done any negative testing in this solution... all of the tests are done around the happy path testing.

1. I know there are lots of Nuget packages I could have made use of (ie. CsvHelper, etc.), but in this case, I decided to hand code the logic so that it is visible on how other reports can be generated.

1. There is not a lot of error handling in this solution, and it lacks logging. I purposely left this out for now provided the short stint at getting this done.

1. While I could have used LINQ to generate the report, I 

## Other Considerations

1. Cloud Adoption: I envisage that the ReportGenerator class library can be used in a Function App with an API endpoint to service the report requests. I also can add the YAML workflows to be used with either Azure DevOps or Github at a time when a suitable cloud option has been discussed.
1. Python Option: While I ran out of time, the optimal solution for this test was to use Python, Dataframes, and a few functions to help fetch the data and generate the report.
