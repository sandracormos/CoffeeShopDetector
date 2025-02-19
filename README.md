# Coffee Shops Finder
<img src="coffeePhoto.jpg" align="right" width="150" height="150">

## Overview


This project is a command-line application that determines the three closest coffee shops to a user's location. Given a CSV file containing coffee shop data, the application calculates the distance between the user's coordinates and each coffee shop, then returns the three closest locations in order of proximity.
## Features

- Fetches CSV data from a provided URL using `HttpClient`.
- Reads CSV data from a local file.
- Asynchronous operations to ensure non-blocking functionality.
- Handles both HTTP URLs and local file paths.

## Getting Started

### Prerequisites

- **.NET SDK**
- Internet connection (to fetch the CSV data from the remote server)

## Input

The program requires the following three arguments to run:
<user_x_coordinate> <user_y_coordinate> <coffee_shop_data_url>

where: 
- `user_x_coordinate`: The X-coordinate of the user's location.
- `user_y_coordinate`: The Y-coordinate of the user's location.
- `coffee_shop_data_url`: The URL of the CSV file that contains the coffee shop data.

Example Input: 47.6 -122.4 https://raw.githubusercontent.com/Agilefreaks/test_oop/master/coffee_shops.csv

## Output

This will calculate and print the three closest coffee shops to the user based on the provided coordinates.

## Handling Malformed Data

If the program encounters any malformed data entries in the CSV file (such as missing or invalid coordinates), it will exit with an error message.



Example Output: 
- Starbucks Seattle2,0.0645
- Starbucks Seattle,0.0861
- Starbucks SF,10.0793
