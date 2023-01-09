import 'package:flutter/material.dart';

class WelcomePage extends StatelessWidget {
  const WelcomePage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            Image.asset(
              'assets/image.jpg',
              width: 300,
            ),
            const SizedBox(
              height: 40,
            ),
            const Text(
              "Math for\neveryone",
              textAlign: TextAlign.center,
              style: TextStyle(
                height: 1.15,
                fontWeight: FontWeight.w600,
                fontStyle: FontStyle.normal,
                fontFamily: 'SF Pro Text',
                fontSize: 48,
                color: Color(0xFF252C32),
              ),
            ),
            const SizedBox(
              height: 35,
            ),
            ElevatedButton(
              style: ElevatedButton.styleFrom(
                backgroundColor: const Color(0xFF252C32),
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(16.0),
                ),
                minimumSize: const Size(280, 46),
              ),
              onPressed: () {
                Navigator.pushNamed(context, '/quiz');
              },
              child: const Text(
                "Start",
                textAlign: TextAlign.center,
                style: TextStyle(
                  height: 0.7,
                  fontWeight: FontWeight.w500,
                  fontStyle: FontStyle.normal,
                  fontFamily: 'SF Pro Text',
                  fontSize: 14,
                  color: Colors.white,
                ),
              ),
            )
          ],
        ),
      ),
    );
  }
}
