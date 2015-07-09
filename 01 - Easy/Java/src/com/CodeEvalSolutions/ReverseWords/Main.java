package com.CodeEvalSolutions.ReverseWords;

import java.io.*;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        List<String> allLines = null;

        try {
            allLines = readFile(new File(args[0]));
        } catch (IOException e) {
            e.printStackTrace();
        }

        for(String singleLine : allLines)
        {
            String[] words = singleLine.split(" ");
            StringBuilder reversedWord = new StringBuilder();

            Collections.reverse(Arrays.asList(words));

            for(String word : words) reversedWord.append(word + " ");

            System.out.println(reversedWord.toString().substring(0, reversedWord.length() - 1));
        }
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
