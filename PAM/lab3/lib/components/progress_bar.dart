import 'package:flutter/material.dart';
import 'package:flutter/animation.dart';

double timerTime = 0.0;

// we use get package for our state management
class ProgressBarWidget extends StatefulWidget {
  const ProgressBarWidget({super.key});

  @override
  State<ProgressBarWidget> createState() => _MyStatefulWidgetState();
}

/// AnimationControllers can be created with `vsync: this` because of TickerProviderStateMixin.
class _MyStatefulWidgetState extends State<ProgressBarWidget>
    with TickerProviderStateMixin {
  late AnimationController controller;

  @override
  void initState() {
    controller = AnimationController(
      vsync: this,
      duration: const Duration(minutes: 1),
    )..addListener(() {
        setState(() {});
      });
    controller.repeat(reverse: true);
    super.initState();
  }

  @override
  void dispose() {
    controller.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    timerTime = controller.value * 100;
    return Stack(children: [
      Padding(
        padding: const EdgeInsets.symmetric(vertical: 101),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            Row(mainAxisAlignment: MainAxisAlignment.center, children: <Widget>[
              Image.asset(
                'assets/clock.png',
                width: 12,
              ),
              Text(
                "\t${(controller.value * 100).round()}s",
                style: const TextStyle(
                  fontWeight: FontWeight.w500,
                  fontStyle: FontStyle.normal,
                  fontFamily: 'SF Pro Text',
                  fontSize: 14,
                  color: Color(0xFF7B7B7B),
                ),
              ),
            ]),
            const SizedBox(
              height: 8,
            ),
            SizedBox(
              width: 342,
              child: ClipRRect(
                borderRadius: const BorderRadius.all(Radius.circular(10)),
                child: LinearProgressIndicator(
                  minHeight: 5,
                  value: controller.value,
                  backgroundColor: const Color(0xFFF4F4F4),
                  valueColor:
                      const AlwaysStoppedAnimation<Color>(Color(0xFF0BBC00)),
                ),
              ),
            )
          ],
        ),
      ),
    ]);
  }
}
