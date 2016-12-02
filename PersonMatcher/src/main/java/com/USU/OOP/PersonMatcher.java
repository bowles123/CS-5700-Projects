package com.USU.OOP;

import com.USU.OOP.Data.DataImporterExporter;
import com.USU.OOP.Data.JSONDataImporterExporter;
import com.USU.OOP.Data.TextImporterExporter;
import com.USU.OOP.Data.XMLDataImporterExporter;
import com.USU.OOP.Person.Person;
import com.USU.OOP.Strategies.*;

import java.util.*;

public class PersonMatcher {
    private  DataImporterExporter importerExporter;
    private  List<Person> people;
    private Map<Person, List<Person>> matches;

    public Map<Person, List<Person>> getMatches() {
        return matches;
    }

    public void setPeople(List<Person> ppl) {
        people = ppl;
    }

    private List<MatchingStrategy> initializeStrategies() {
        List<MatchingStrategy> strategies = new ArrayList<MatchingStrategy>();

        strategies.add(new CompleteBirthNameGenderStrategy());
        strategies.add(new IdentBirthMotherStrategy());
        strategies.add(new IdentBirthStrategy());
        strategies.add(new IdentNameMotherStrategy());
        strategies.add(new IdentNameStrategy());

        return strategies;
    }

    public void match() {
        List<MatchingStrategy> strategies = initializeStrategies();
        List<Person> m = new ArrayList<Person>();
        String match;
        matches = new HashMap<Person, List<Person>>();

        for (int i = 0; i < people.size(); i++) {
            for (int j = i + 1; j < people.size(); j++) {
                for (MatchingStrategy strategy : strategies) {
                    match = strategy.Match(people.get(i), people.get(j));
                    if (match != null) {
                        if (match.equals("TRUE")) {
                            m.add(people.get(j));
                            break;
                        } else if (match.equals("FALSE")) {
                            break;
                        }
                    }
                }
            }
            matches.put(people.get(i), m);
            m = new ArrayList<Person>();
        }
    }

    public List<Person> readInData(String inputType, String inFile, String filePath) {
        List<Person> people;

        if (inputType.toUpperCase().equals("JSON")) {
            importerExporter = new JSONDataImporterExporter("", filePath);
        } else {
            importerExporter = new XMLDataImporterExporter(filePath);
        }

        importerExporter.parseFile(inFile);
        people = importerExporter.getPeople();
        return people;
    }

    public void displayData() {
        for (Map.Entry<Person, List<Person>> entry : matches.entrySet()) {
            if (entry.getValue().size() != 0)
            {
                System.out.println("\tMatches for " + entry.getKey().get_objectId() + ":");

                for (Person person : entry.getValue()) {
                    System.out.print("\t\t" + person.get_objectId() + " ");
                }
                System.out.println();
            }
        }
    }

    public void writeOutData(String outFile) {
        importerExporter = new TextImporterExporter();
        importerExporter.saveData(outFile, matches);
    }
}
