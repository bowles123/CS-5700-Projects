package com.USU.OOP.Data;

import com.USU.OOP.Person.Person;
import sun.reflect.generics.reflectiveObjects.NotImplementedException;

import javax.management.Notification;
import java.io.FileWriter;
import java.io.IOException;
import java.util.List;
import java.util.Map;

/**
 * Created by Brian Bowles (9/12/16, 9:26 PM).
 */

public class TextImporterExporter extends DataImporterExporter {
    @Override
    public boolean parseFile(String fileName) throws NotImplementedException {
        System.out.println("Parsing data from a text file is not implemented.");
        throw new NotImplementedException();
    }

    @Override
    public void saveData(String fileName, Map<Person, List<Person>> matches) {
        try {
            FileWriter fileWriter = new FileWriter(fileName);
            fileWriter.write("Matching pairs:\n");

            for (Map.Entry<Person, List<Person>> entry : matches.entrySet()) {
                for (Person person : entry.getValue()) {
                    fileWriter.write("(" + entry.getKey().get_objectId() + ", " + person.get_objectId() + ")\n");
                }
            }

            fileWriter.close();

        }catch (IOException e) {
            System.out.println("Problem writing to file.");
            e.printStackTrace();
        }
    }
}
