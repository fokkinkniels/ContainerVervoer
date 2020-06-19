# ContainerVisualizer-WebSocket

## Introduction

In semester 2 students from Software Engineering have an assignment "Containervervoer" (see Canvas course [S-DB-S2-CMK](https://fhict.instructure.com/courses/9493/pages/oefening-containervervoer?module_item_id=468091)).
In short: given a list of different type of containers and some placement rules/constraints you have to find a way to place all containers on the ship without capsizing.
Testing and debugging this 3D layout can be quite challenging, so I created a website where you can see a realtime interactable ship with your generated container layout.
You can give this containerlayout through url arguments (see assignment for the syntax). This url can be easily generated from your own implementation of the assignment.

Limitations:  
-the url length is restricted to ~2100 characters depending on browser so "only" ~660 (light) containers can be placed  
-running several layouts in sequence is not that fast because the website and Unity WebGL instance has to be loaded every time which takes approx. ~5 seconds  
-only visual testing was supported, the stats and constraint tests were not available except in the UI  

So to circumvent these limitations I have created this example project which consists of a socketserver to which the website automatically connects to.
Through this connection you can send the containerlayout (which are the same url arguments as the other method).
You can easily integrate this example in your solution for the ContainerVervoer assignment.

## Changelog

With the latest version of the website (v0.42 or higher) it will return all stats, notices, warnings and errors back in JSON format. For example:
```json
 {
  "MinWeight": 1200.0,
  "MaxWeight": 2400.0,
  "Weight": 342.0,
  "TotalContainers": 16,
  "NumContainersPerType": "4xValuable, 4xValuable, Coolable, 7xNormal, 1xCoolable",
  "heightVariance": 0.0,
  "weightDifferenceAsPercentage": "0",
  "shipErrorFlags": "ValuableContainerNotReachable, CoolableContainerNotInFront, NotEnoughCargo",
  "containerStackErrorFlags": "None",
  "containerErrorFlags": "TooLessWeightInsideContainer, TooMuchWeightInsideContainer",
  "validContainerLayout": false,
  "notices": [],
  "warnings": [
    "Warning: not a valid container layout!\n shipErrorFlags: ValuableContainerNotReachable, CoolableContainerNotInFront, NotEnoughCargo\n containerStackErrorFlags: None\n containerErrorFlags: TooLessWeightInsideContainer, TooMuchWeightInsideContainer"
  ],
  "errors": []
}
```

## Usage

1. Just run the [ContainerVisualizer](https://i872272core.venus.fhict.nl/ContainerVisualizer/) website
2. Open the example project in Visual Studio and run it
3. The website will automatically connect to the example project
4. Press enter in the example project to send a random generated ship layout to the website
5. You will receive all stats, notices, warnings and errors back in JSON format AND website will be updated with new ship layout

## Dependencies

WebSocket server - Fleck - https://github.com/statianzo/Fleck  
Beautifying JSON result (optional) - NewtonSoft - https://www.newtonsoft.com/json  

## Known issues

None