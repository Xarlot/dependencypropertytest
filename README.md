This project tests the performance of dependency properties in WinUI for Desktop application and compares results with a similar scenario in WPF platform.

##### Configurations

|Platform    |              Config                                     |
|------------|---------------------------------------------------------|
|Wpf         | Release                                                 |
|WinUI p3    | WinUI for Desktop Preview 3, Release, x64               |


##### Results
|Scenario        |WPF|WinUI p3|
|----------------|---|--------|
|Set 200K times  |42 |11905   |
|Read 200K times |7  |1465    |