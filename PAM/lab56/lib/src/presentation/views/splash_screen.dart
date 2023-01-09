import 'dart:async';
import 'package:flutter/material.dart';
import 'package:lab5/src/presentation/views/home_screen.dart';

class SplashScreen extends StatefulWidget {
  const SplashScreen({Key? key}) : super(key: key);

  @override
  State<SplashScreen> createState() => _SplashScreenState();
}

class _SplashScreenState extends State<SplashScreen> {
  @override
  void initState() {
    super.initState();
    Timer(const Duration(seconds: 2), () {
    // Navigate to home screen
      Navigator.of(context).pushReplacement(
        MaterialPageRoute(builder: (BuildContext context) => const HomeScreen()));
    });
  }
  @override
  Widget build(BuildContext context) {
    return const Scaffold(
      body: Center(
        child: Text("Splash Screen"),
      ),
    );
  }
}
