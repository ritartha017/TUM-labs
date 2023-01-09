import 'package:flutter/material.dart';
import 'package:lab3/quiz.dart';
import 'package:lab3/result.dart';
import 'package:lab3/welcome.dart';

void main() => runApp(const MyApp());

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: const WelcomePage(),
      routes: {
        '/quiz': (context) => const QuizPage(),
        '/result': (context) => ResultPage()
      },
    );
  }
}
