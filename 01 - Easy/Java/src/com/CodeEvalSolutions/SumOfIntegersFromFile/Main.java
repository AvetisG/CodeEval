package com.CodeEvalSolutions.SumOfIntegersFromFile;

import java.io.*;
import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        List<String> allLines = null;
        int finalSum = 0;

        try {
            allLines = readFile(new File(args[0]));
        } catch (IOException e) {
            e.printStackTrace();
        }

        for(String singleLine : allLines) finalSum = finalSum + Integer.parseInt(singleLine);

        System.out.println(finalSum);
    }

    private static List<String> readFile(File fin) throws IOException {

        ArrayList<String> file = new ArrayList<String>();

        FileInputStream fis = new FileInputStream(fin);

        BufferedReader br = new BufferedReader(new InputStreamReader(fis));

        String line = null;

        while ((line = br.readLine()) != null) {
            file.add(line);
        }

        br.close();

        return file;
    }
}
