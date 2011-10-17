namespace AIMA.Core.Environment.Map
{
    using System;
    using System.Collections.Generic;
    using AIMA.Core.Util.DataStructure;

    /**
     * Provides a general interface for maps.
     * 
     * @author Ruediger Lunde
     */
    public interface Map
    {

        /** Returns a list of all locations. */
         List<String> getLocations();

        /**
         * Answers to the question: Where can I get, following one of the
         * connections starting at the specified location?
         */
         List<String> getLocationsLinkedTo(String fromLocation);

        /**
         * Returns the travel distance between the two specified locations if they
         * are linked by a connection and null otherwise.
         */
         Double getDistance(String fromLocation, String toLocation);

        /**
         * Returns the position of the specified location. The position is
         * represented by two coordinates, e.g. latitude and longitude values.
         */
         Point2D getPosition(String loc);

        /**
         * Returns a location which is selected by random.
         */
         String randomlyGenerateDestination();
    }
}
