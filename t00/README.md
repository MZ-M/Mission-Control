# Smart Travel Planner

A Windows Forms application for planning travel routes between cities using graph algorithms.

## Features

- Create and manage travelers with name and current location
- Load city maps from text files
- Plan optimal routes using Dijkstra's algorithm
- Save and load traveler data in JSON format
- Display route information and total distance

## Requirements

- .NET 8.0 SDK
- Windows OS

## Building

Build the project using:

```bash
dotnet build SmartTravelPlanner/Project.sln -c Release -m
```

## Usage

1. **Create Traveler**: Enter traveler name and current location, then click "Create Traveler"
2. **Load Map**: Click "Load Map" and select a `.txt` file containing city connections
3. **Plan Route**: Enter destination and click "Plan Route"
4. **Save/Load**: Use "Save Traveler" and "Load Traveler" buttons to persist traveler data

## Map File Format

Map files should be in the following format:
```
CityA-CityB,Distance
CityB-CityC,Distance
...
```

Example:
```
Moscow-Saint-Petersburg,635
Saint-Petersburg-Helsinki,392
Moscow-Kazan,821
```

## Project Structure

```
SmartTravelPlanner/
    Project.sln
    SmartTravelPlanner/
        Form1.cs          - Main form UI
        Traveler.cs       - Traveler class with JSON serialization
        CityGraph.cs      - Graph implementation with Dijkstra algorithm
        Program.cs        - Application entry point
diagrams/
    usecase.png          - Use Case diagram
    activity.png         - Activity diagram
    sequence.png         - Sequence diagram
```

## Error Handling

The application displays MessageBox dialogs for:
- Map file not found or invalid format
- Destination not reachable
- Destination not in map
- Traveler field empty
- Destination field empty
- Invalid .json file during loading

## Technologies

- C# (.NET 8.0)
- Windows Forms
- Newtonsoft.Json for serialization
- Dijkstra's algorithm for pathfinding

