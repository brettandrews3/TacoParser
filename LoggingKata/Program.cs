﻿using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

/* 1. Start with your unit tests
2. Next, complete the Parse() method
3. Complete Program.cs */

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger(); //instance of TacoLogger class
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS
            // Grab the path from the name of your file




            // Now, here's the new code

            // Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the furthest from each other.
            // Create a `double` variable to store the distance
            ITrackable tacobell1 = null;
            ITrackable tacobell2 = null;
            double distance = 0;

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`<--ALREADY DECLARED

            //DONE HINT NESTED LOOPS SECTION---------------------
            //DONE Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            for (int i = 0; i < locations.Length; i++)
            {
                var corA = new GeoCoordinate();
                corA.Latitude = locations[i].Location.Latitude;
                corA.Longitude = locations[i].Location.Longitude;

                for (int j = 0; j < locations.Length; j++)
                {
                    var corB = new GeoCoordinate();
                    corB.Latitude = locations[j].Location.Latitude;
                    corB.Longitude = locations[j].Location.Longitude;
                    if(corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        //give it a value
                        tacobell1 = locations[i];
                        tacobell2 = locations[j];
                    }
                }
            }
            logger.LogInfo($"The two locations furthest away from each other " +
                $"are {tacobell1.Name} and {tacobell2.Name}, with a distance of {parser.ConvertMetersToMiles(distance)} miles.");
            //DONE Create a new corA Coordinate with your locA's lat and long

            //DONE Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

            //DONE Create a new Coordinate with your locB's lat and long

            //DONE Now, compare the two using `.GetDistanceTo()`, which returns a double
            //DONE If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            //DONE Once you've looped through everything, you've found the two Taco Bells furthest away from each other.

            /* Convert the distance to miles. Round to 2 decimal places.
            Create a method to convert metres to miles in the TacoParser class
            Write a unit test for the method in your tests
            Implement method in Program.cs */
            // Conversion: "var distanceInMiles = distanceInMetres / 1609;"

        }
    }
}
