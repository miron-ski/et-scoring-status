# Tournament Scoring Status Table

## Overview

A web application built using the Blazor framework. It displays a list of players for a given tournament, allowing users to visualize player scores for each round.

[View Application](https://scoringstatus20231212130446.azurewebsites.net/)
   

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed
- [BUnit](https://bunit.dev/) for testing

### Installation

1.  **Clone the repository:**
   
   ```bash
   git clone https://github.com/mirons-atos/et-scoring-status.git
   ```

2.  **Navigate to the project directory:**
   
   ```bash
   cd et-scoring-status/ScoringStatus
   ```

3.  **Run the application:**
   
   ```bash
   dotnet run
   ```

4. Open your web browser and navigate to localhost.

## Features

### Player List

The application displays a list of players for a given tournament, including dynamic columns for each round.

Upon launching the application, the player data for the default tournament will be displayed. Each row represents a player, and columns represent different rounds.

### Search

The application provides a search feature that allows users to filter players by their last names. To reset the search view click the Reset button.

### Sorting

Match, Score and Position columns in the player list are sortable, allowing users to easily organize and analyze player data.

Click on the column headers to sort the player list based on the selected column. Clicking again will toggle between ascending and descending order.


## Testing

### Unit Tests

The application includes a suite of unit tests to ensure the correctness of its functionalities. BUnit was used as the testing framework. 

## Deployment

Hosted on Microsoft Azure App Service.
