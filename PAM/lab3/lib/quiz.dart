import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:lab3/components/progress_bar.dart';

class QuizPage extends StatefulWidget {
  const QuizPage({super.key});

  @override
  _QuizPageState createState() => _QuizPageState();
}

class _QuizPageState extends State<QuizPage> {
  var questions = [];
  int index = 0;

  int rightAnswerCount = 0;
  int wrongAnswerCount = 0;

  @override
  void initState() {
    super.initState();
    fetchQuestion();
  }

  fetchQuestion() async {
    String data = await DefaultAssetBundle.of(context)
        .loadString("assets/questions.json");
    var resp = jsonDecode(data);
    setState(() {
      questions = resp["questions"];
    });
  }

  validate(i) {
    if (questions[index]["answerIndex"] == i) {
      setState(() {
        rightAnswerCount++;
      });
    } else {
      setState(() {
        wrongAnswerCount++;
      });
    }

    if (index < questions.length - 1) {
      setState(() {
        index++;
      });
    } else {
      Navigator.pushNamed(context, '/result', arguments: {
        'right': rightAnswerCount,
        'wrong': rightAnswerCount,
        'total': questions.length,
        'timerTime': timerTime,
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      body: questions.isNotEmpty
          ? Center(
              child: Container(
                  height: 844,
                  width: 342,
                  child: Column(children: <Widget>[
                    const ProgressBarWidget(),
                    Align(
                      alignment: Alignment.topLeft,
                      child: Text(
                        'Question ${index + 1} of ${questions.length}',
                        style: const TextStyle(
                          height: 0.2,
                          fontWeight: FontWeight.w500,
                          fontStyle: FontStyle.normal,
                          fontFamily: 'SF Pro Text',
                          fontSize: 14,
                          color: Color(0xFF7B7B7B),
                        ),
                      ),
                    ),
                    const SizedBox(
                      height: 17,
                    ),
                    Align(
                      alignment: Alignment.topLeft,
                      child: Text(
                        questions[index]["question"],
                        style: const TextStyle(
                          height: 0.6,
                          fontWeight: FontWeight.w500,
                          fontStyle: FontStyle.normal,
                          fontFamily: 'SF Pro Text',
                          fontSize: 14,
                          color: Color(0xFF252C32),
                        ),
                      ),
                    ),
                    const SizedBox(
                      height: 12,
                    ),
                    Padding(
                      padding: const EdgeInsets.only(top: 8),
                      child: ElevatedButton(
                          style: ElevatedButton.styleFrom(
                              backgroundColor: Colors.white,
                              shape: RoundedRectangleBorder(
                                borderRadius: BorderRadius.circular(16.0),
                              ),
                              minimumSize: const Size(342, 54),
                              side: const BorderSide(
                                width: 2.0,
                                color: Color(0xFFF4F4F4),
                              )),
                          onPressed: () => validate(2),
                          child: Row(
                              mainAxisAlignment: MainAxisAlignment.spaceBetween,
                              children: [
                                Text(
                                  "\t\t\t${questions[index]["options"][0]}",
                                  style: const TextStyle(
                                    color: Color(0xFF7B7B7B),
                                    fontSize: 14,
                                    fontWeight: FontWeight.w600,
                                    height: 0.6,
                                  ),
                                ),
                                Container(
                                    height: 20,
                                    width: 20,
                                    decoration: BoxDecoration(
                                      border: Border.all(
                                          color: const Color(0xFFF4F4F4)),
                                      borderRadius: BorderRadius.circular(50),
                                    )),
                              ])),
                    ),
                    Padding(
                      padding: const EdgeInsets.only(top: 8),
                      child: ElevatedButton(
                          style: ElevatedButton.styleFrom(
                              backgroundColor: Colors.white,
                              shape: RoundedRectangleBorder(
                                borderRadius: BorderRadius.circular(16.0),
                              ),
                              minimumSize: const Size(342, 54),
                              side: const BorderSide(
                                width: 2.0,
                                color: Color(0xFFF4F4F4),
                              )),
                          onPressed: () => validate(2),
                          child: Row(
                              mainAxisAlignment: MainAxisAlignment.spaceBetween,
                              children: [
                                Text(
                                  "\t\t\t${questions[index]["options"][1]}",
                                  style: const TextStyle(
                                    color: Color(0xFF7B7B7B),
                                    fontSize: 14,
                                    fontWeight: FontWeight.w600,
                                    height: 0.6,
                                  ),
                                ),
                                Container(
                                    height: 20,
                                    width: 20,
                                    decoration: BoxDecoration(
                                      border: Border.all(
                                          color: const Color(0xFFF4F4F4)),
                                      borderRadius: BorderRadius.circular(50),
                                    )),
                              ])),
                    ),
                    Padding(
                        padding: const EdgeInsets.only(top: 8),
                        child: ElevatedButton(
                          style: ElevatedButton.styleFrom(
                              backgroundColor: Colors.white,
                              shape: RoundedRectangleBorder(
                                borderRadius: BorderRadius.circular(16.0),
                              ),
                              minimumSize: const Size(342, 54),
                              side: const BorderSide(
                                width: 2.0,
                                color: Color(0xFFF4F4F4),
                              )),
                          onPressed: () => validate(2),
                          child: Align(
                              alignment: Alignment.topLeft,
                              child: Row(
                                  mainAxisAlignment:
                                      MainAxisAlignment.spaceBetween,
                                  children: [
                                    Text(
                                      "\t\t\t${questions[index]["options"][2]}",
                                      style: const TextStyle(
                                        color: Color(0xFF7B7B7B),
                                        fontSize: 14,
                                        fontWeight: FontWeight.w600,
                                        height: 0.6,
                                      ),
                                    ),
                                    Container(
                                        height: 20,
                                        width: 20,
                                        decoration: BoxDecoration(
                                          border: Border.all(
                                              color: const Color(0xFFF4F4F4)),
                                          borderRadius:
                                              BorderRadius.circular(50),
                                        )),
                                  ])),
                        )),
                    Padding(
                      padding: const EdgeInsets.only(top: 8),
                      child: ElevatedButton(
                          style: ElevatedButton.styleFrom(
                              backgroundColor: Colors.white,
                              shape: RoundedRectangleBorder(
                                borderRadius: BorderRadius.circular(16.0),
                              ),
                              minimumSize: const Size(342, 54),
                              side: const BorderSide(
                                width: 2.0,
                                color: Color(0xFFF4F4F4),
                              )),
                          onPressed: () => validate(2),
                          child: Row(
                              mainAxisAlignment: MainAxisAlignment.spaceBetween,
                              children: [
                                Text(
                                  "\t\t\t${questions[index]["options"][3]}",
                                  style: const TextStyle(
                                    color: Color(0xFF7B7B7B),
                                    fontSize: 14,
                                    fontWeight: FontWeight.w600,
                                    height: 0.6,
                                  ),
                                ),
                                Container(
                                    height: 20,
                                    width: 20,
                                    decoration: BoxDecoration(
                                      border: Border.all(
                                          color: const Color(0xFFF4F4F4)),
                                      borderRadius: BorderRadius.circular(50),
                                    )),
                              ])),
                    ),
                  ])),
            )
          : Container(),
    );
  }
}
