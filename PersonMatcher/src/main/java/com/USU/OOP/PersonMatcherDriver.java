package com.USU.OOP;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

/**
 * Created by Brian Bowles (9/15/16, 6:45 PM).
 */

public class PersonMatcherDriver {
    public static void main(String[] args) {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        PersonMatcher matcher = new PersonMatcher();
        String path = "", file = "", outputPath = "TextOutput/";

        try {
            System.out.print("Please enter the file path (i.e. C:/Users/..../, without the filename." +
                    " Note that \"\" path equates to the project main directory.): ");
            path = reader.readLine();

            System.out.print("Please enter the filename: ");
            file = reader.readLine();
        } catch (IOException e) {
            System.out.println("Error reading from console.");
            e.printStackTrace();
        }

        if (file.contains("json")) {
            matcher.setPeople(matcher.readInData("JSON", file, path));
            matcher.match();
            System.out.println("JSON way:");
            matcher.displayData();
            matcher.writeOutData(outputPath + "json_matches.txt");
        } else if (file.contains("xml")) {
            matcher.setPeople(matcher.readInData("XML", file, path));
            matcher.match();
            System.out.println("XML way:");
            matcher.displayData();
            matcher.writeOutData(outputPath + "xml_matches.txt");
        } else {
            System.out.println("This program can only parse JSON or XML.");
        }
    }
}
