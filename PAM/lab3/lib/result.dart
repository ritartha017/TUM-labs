import 'package:flutter/material.dart';

class ResultPage extends StatelessWidget {
  var data;

  ResultPage({super.key});

  @override
  Widget build(BuildContext context) {
    data = ModalRoute.of(context)?.settings.arguments;

    return Scaffold(
        body: Center(
            child: Column(
                crossAxisAlignment: CrossAxisAlignment.center,
                mainAxisAlignment: MainAxisAlignment.center,
                children: <Widget>[
          Container(
            height: 318,
            width: 342,
            decoration: BoxDecoration(
              border: Border.all(color: const Color(0xFFF0F0F0)),
              borderRadius: BorderRadius.circular(16),
            ),
            child: Column(
              children: <Widget>[
                Row(
                    mainAxisAlignment: MainAxisAlignment.spaceAround,
                    children: const [
                      Text(
                        "Score",
                        style: TextStyle(
                          color: Color(0xFF7B7B7B),
                          fontSize: 14,
                          fontWeight: FontWeight.w600,
                          height: 0.6,
                        ),
                      ),
                      Text(
                        "Correct",
                        style: TextStyle(
                          color: Color(0xFF7B7B7B),
                          fontSize: 14,
                          fontWeight: FontWeight.w600,
                          height: 0.6,
                        ),
                      ),
                      Text(
                        "Completed In",
                        style: TextStyle(
                          color: Color(0xFF7B7B7B),
                          fontSize: 14,
                          fontWeight: FontWeight.w600,
                          height: 0.6,
                        ),
                      ),
                    ]),
                const SizedBox(
                  height: 24,
                ),
                Row(
                    mainAxisAlignment: MainAxisAlignment.spaceAround,
                    children: [
                      const Text(
                        "Score",
                        style: TextStyle(
                          color: Colors.black,
                          fontSize: 18,
                          fontWeight: FontWeight.w600,
                          height: 0.6,
                        ),
                      ),
                      Text(
                        "${data["right"].toString()} / ${data["total"].toString()}",
                        style: const TextStyle(
                          color: Colors.black,
                          fontSize: 18,
                          fontWeight: FontWeight.w600,
                          height: 0.6,
                        ),
                      ),
                      Text(
                        "${(data["timerTime"]).round()}s",
                        style: const TextStyle(
                          color: Colors.black,
                          fontSize: 18,
                          fontWeight: FontWeight.w600,
                          height: 0.6,
                        ),
                      ),
                    ])
              ],
            ),
          ),
        ])));
  }
}

