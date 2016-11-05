package com.USU.OOP.Data;

import com.USU.OOP.Creators.CreateAdultFromJSON;
import com.USU.OOP.Creators.CreateChildFromJSON;
import com.USU.OOP.Person.Person;

import java.io.*;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

/**
 * Created with IntelliJ IDEA.
 * User: User
 * Date: 9/6/16
 * Time: 12:58 PM
 * To change this template use File | Settings | File Templates.
 */

public class JSONDataImporterExporter extends DataImporterExporter {
    private String jsonString;

    private  void createObjects() {
        try {
            JSONArray objects = new JSONArray(jsonString);

            for(int i = 0; i < objects.length(); i++) {
                JSONObject object = objects.getJSONObject(i);

                if (object.getString("__type").contains("Adult")) {
                    people.add(createPerson(object, new CreateAdultFromJSON()));
                } else {
                    people.add(createPerson(object, new CreateChildFromJSON()));
                }
            }

        } catch(JSONException exception) {

        }
    }

    public JSONDataImporterExporter(String string, String path) {
        super();
        jsonString = string;
        filePath = path;
    }

    @Override
    public void saveData(String fileName, Map<Person, List<Person>> matches) {
        System.out.println("Saving data in JSON format is not implemented.");
    }

    @Override
    public void parseFile(String fileName) {
        String file = filePath + fileName;

        try {
            jsonString = new String(Files.readAllBytes(Paths.get(file)));
            createObjects();
        }
        catch(FileNotFoundException exception) {
            System.out.println("Unable to locate file: " + fileName);
            exception.printStackTrace();
        }
        catch(IOException exception) {
            System.out.println("Unable to parse file: " + fileName);
            exception.printStackTrace();
        }
    }
}