import 'package:lab5/src/presentation/blocs/newsbloc/news_bloc.dart';
import 'package:lab5/src/presentation/blocs/newsbloc/news_states.dart';
import 'package:lab5/src/data/repositories/news_repository.dart';
import 'package:lab5/src/presentation/views/article_screen.dart';
import 'package:lab5/src/presentation/views/splash_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatefulWidget {
  const MyApp({super.key});

  @override
  _MyAppState createState() => _MyAppState();
}

class _MyAppState extends State<MyApp> {
  @override
  Widget build(BuildContext context) {
    return MultiBlocProvider(
      providers: [
        BlocProvider<NewsBloc>(
          create: (context) => NewsBloc(
              initialState: NewsInitState(), newsRepository: NewsRepository()),
        )
      ],
      child: MaterialApp(
        debugShowCheckedModeBanner: false,
        theme: ThemeData(
            scaffoldBackgroundColor: Colors.white,
           ),
        home: const SplashScreen(),
        routes: {
          "/article_screen": (context) => ArticleScreen()
        },
      ),
    );
  }
}
