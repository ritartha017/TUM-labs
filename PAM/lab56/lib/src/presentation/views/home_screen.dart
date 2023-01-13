import 'package:cached_network_image/cached_network_image.dart';
import 'package:lab5/src/presentation/blocs/newsbloc/news_bloc.dart';
import 'package:lab5/src/presentation/blocs/newsbloc/news_states.dart';
import 'package:lab5/src/domain/models/article_model.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:lab5/src/domain/models/featured_model.dart';
import 'package:lab5/src/presentation/views/article_screen.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({super.key});

  @override
  _HomeScreenState createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  @override
  Widget build(BuildContext context) {
    var height = MediaQuery.of(context).size.height;

    return Scaffold(
      body: Stack(
        children: [
          Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Container(
                margin: const EdgeInsets.fromLTRB(16, 45, 16, 16),
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: const <Widget>[
                    Text(
                      "Featured",
                      style: TextStyle(
                          fontSize: 20,
                          fontWeight: FontWeight.bold,
                          color: Color.fromRGBO(44, 58, 75, 1)),
                    ),
                    Text(
                      "See all",
                      style: TextStyle(
                          fontSize: 16,
                          fontWeight: FontWeight.bold,
                          color: Color.fromRGBO(255, 104, 97, 1)),
                    )
                  ],
                ),
              ),
            ],
          ),
          Container(
            color: Colors.white,
            margin: EdgeInsets.only(top: height * 0.1),
            child: BlocBuilder<NewsBloc, NewsStates>(
              builder: (BuildContext context, NewsStates state) {
                if (state is NewsLoadingState) {
                  return const Center(child: CircularProgressIndicator());
                } else if (state is NewsLoadedState) {
                  List<ArticleModel> articleList = [];
                  List<FeaturedModel> featuredList = [];
                  articleList = state.articleList;
                  featuredList = state.featuredList;
                  return Column(children: <Widget>[
                    SizedBox(
                      height: 300,
                      child: featuredList.isNotEmpty
                          ? Expanded(
                              child: ListView.builder(
                                itemCount: featuredList.length,
                                scrollDirection: Axis.horizontal,
                                itemBuilder: (context, index) {
                                  return Container(
                                      margin: const EdgeInsets.fromLTRB(
                                          16, 20, 10, 22),
                                      child: Stack(children: <Widget>[
                                        ClipRRect(
                                          borderRadius:
                                              BorderRadius.circular(24),
                                          child: CachedNetworkImage(
                                              imageUrl:
                                                  featuredList[index].cover!,
                                              width: 310,
                                              height: 252,
                                              fit: BoxFit.cover),
                                        ),
                                        Container(
                                          margin: const EdgeInsets.fromLTRB(
                                              12, 0, 12, 24),
                                          width: 280,
                                          child: Column(
                                            crossAxisAlignment:
                                                CrossAxisAlignment.start,
                                            mainAxisAlignment:
                                                MainAxisAlignment.end,
                                            children: <Widget>[
                                              Text(
                                                featuredList[index].title!,
                                                overflow: TextOverflow.ellipsis,
                                                style: const TextStyle(
                                                    fontSize: 20,
                                                    fontWeight: FontWeight.bold,
                                                    color: Color.fromRGBO(
                                                        255, 255, 255, 1)),
                                              ),
                                              Container(
                                                margin:
                                                    const EdgeInsets.fromLTRB(
                                                        0, 15, 0, 0),
                                                width: 100,
                                                height: 36,
                                                padding:
                                                    const EdgeInsets.fromLTRB(
                                                        16, 10, 16, 10),
                                                decoration: const BoxDecoration(
                                                  color: Color.fromRGBO(
                                                      254, 131, 125, 1),
                                                  borderRadius:
                                                      BorderRadius.all(
                                                    Radius.circular(24),
                                                  ),
                                                ),
                                                child: const Text(
                                                  'Read Now',
                                                  style: TextStyle(
                                                      fontSize: 14,
                                                      fontWeight:
                                                          FontWeight.bold,
                                                      color: Color.fromRGBO(
                                                          255, 255, 255, 1)),
                                                ),
                                              )
                                            ],
                                          ),
                                        )
                                      ]));
                                },
                              ),
                            )
                          : Container(),
                      // ])
                    ),
                    Container(
                      margin: const EdgeInsets.fromLTRB(16, 0, 16, 0),
                      child: Row(
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        children: const <Widget>[
                          Text(
                            "News",
                            style: TextStyle(
                                fontSize: 20,
                                fontWeight: FontWeight.bold,
                                color: Color.fromRGBO(44, 58, 75, 1)),
                          ),
                          Text(
                            "See all",
                            style: TextStyle(
                                fontSize: 16,
                                fontWeight: FontWeight.bold,
                                color: Color.fromRGBO(255, 104, 97, 1)),
                          )
                        ],
                      ),
                    ),
                    Expanded(
                      child: ListView.builder(
                          itemCount: articleList.length,
                          itemBuilder: (context, index) {
                            return GestureDetector(
                                onTap: () async
                                => Navigator.of(context).pushNamed('/article_screen',
                                    arguments: {'article_index':index, 'title': articleList[index].title, 'cover': articleList[index].cover}),
                                child: Container(
                                    margin: const EdgeInsets.fromLTRB(
                                        16, 0, 16, 12),
                                    width: 358,
                                    height: 156,
                                    decoration: BoxDecoration(
                                      borderRadius: const BorderRadius.all(
                                          Radius.circular(
                                              16) //                 <--- border radius here
                                          ),
                                      border: Border.all(
                                          color: const Color.fromRGBO(
                                              235, 238, 242, 1)),
                                    ),
                                    child: Row(
                                      mainAxisAlignment:
                                          MainAxisAlignment.start,
                                      children: <Widget>[
                                        ClipRRect(
                                          borderRadius: const BorderRadius.only(
                                            topLeft: Radius.circular(16.0),
                                            bottomLeft: Radius.circular(16.0),
                                          ),
                                          child: Image.network(
                                              articleList[index].cover ??
                                                  "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSojwMMYZgtiupM4Vzdb5iBeE4b0Mamf3AgrxQJR19Xa4oIWV5xun9a02Ggyh4bZAurP_c&usqp=CAU",
                                              width: 150,
                                              height: 156,
                                              fit: BoxFit.cover),
                                        ),
                                        Flexible(
                                            child: Container(
                                                margin:
                                                    const EdgeInsets.fromLTRB(
                                                        16, 24, 24, 16),
                                                child: Column(
                                                  mainAxisAlignment:
                                                      MainAxisAlignment
                                                          .spaceBetween,
                                                  children: <Widget>[
                                                    Text(
                                                      articleList[index].title!,
                                                      overflow:
                                                          TextOverflow.ellipsis,
                                                      maxLines: 2,
                                                      style: const TextStyle(
                                                          fontSize: 18,
                                                          fontWeight:
                                                              FontWeight.bold,
                                                          color: Color(
                                                              0xFF2C3A4B)),
                                                    ),
                                                    Row(
                                                      mainAxisAlignment:
                                                          MainAxisAlignment
                                                              .start,
                                                      children: <Widget>[
                                                        Container(
                                                          margin:
                                                              const EdgeInsets
                                                                      .fromLTRB(
                                                                  0, 0, 4, 0),
                                                          child: ClipRRect(
                                                            borderRadius:
                                                                BorderRadius
                                                                    .circular(
                                                                        50),
                                                            child: Image.network(
                                                                articleList[
                                                                        index]
                                                                    .portal!
                                                                    .logo,
                                                                width: 16,
                                                                height: 16,
                                                                fit: BoxFit
                                                                    .cover),
                                                          ),
                                                        ),
                                                        Container(
                                                          margin:
                                                              const EdgeInsets
                                                                      .fromLTRB(
                                                                  0, 0, 16, 0),
                                                          child: Text(
                                                            articleList[index]
                                                                .portal!
                                                                .title,
                                                            style: const TextStyle(
                                                                fontWeight:
                                                                    FontWeight
                                                                        .bold,
                                                                fontSize: 10,
                                                                color: Color
                                                                    .fromRGBO(
                                                                        44,
                                                                        58,
                                                                        75,
                                                                        1)),
                                                          ),
                                                        ),
                                                        Container(
                                                          padding:
                                                              const EdgeInsets
                                                                      .fromLTRB(
                                                                  8, 2, 8, 2),
                                                          decoration:
                                                              BoxDecoration(
                                                            border: Border.all(
                                                                color: const Color
                                                                        .fromRGBO(
                                                                    255,
                                                                    104,
                                                                    97,
                                                                    1)),
                                                            borderRadius:
                                                                const BorderRadius
                                                                        .all(
                                                                    Radius.circular(
                                                                        18) //                 <--- border radius here
                                                                    ),
                                                          ),
                                                          child: Text(
                                                            articleList[index]
                                                                    .category ??
                                                                "",
                                                            style: const TextStyle(
                                                                fontWeight:
                                                                    FontWeight
                                                                        .bold,
                                                                fontSize: 10,
                                                                color: Color
                                                                    .fromRGBO(
                                                                        255,
                                                                        104,
                                                                        97,
                                                                        1)),
                                                          ),
                                                        )
                                                      ],
                                                    ),
                                                    Row(
                                                      mainAxisAlignment:
                                                          MainAxisAlignment
                                                              .spaceBetween,
                                                      children: <Widget>[
                                                        Container(
                                                            margin:
                                                                const EdgeInsets
                                                                        .fromLTRB(
                                                                    0, 0, 0, 0),
                                                            child: Image.asset(
                                                                'assets/images/Likes.png')),
                                                        Container(
                                                            margin:
                                                                const EdgeInsets
                                                                        .fromLTRB(
                                                                    0,
                                                                    0,
                                                                    18.67,
                                                                    0),
                                                            child: Text(
                                                                articleList[
                                                                        index]
                                                                    .likes
                                                                    .toString(),
                                                                style: const TextStyle(
                                                                    fontSize:
                                                                        10,
                                                                    color: Color
                                                                        .fromRGBO(
                                                                            44,
                                                                            58,
                                                                            75,
                                                                            1)))),
                                                        Container(
                                                            margin:
                                                                const EdgeInsets
                                                                        .fromLTRB(
                                                                    0, 0, 0, 0),
                                                            child: Image.asset(
                                                                'assets/images/Comments.png')),
                                                        Container(
                                                            margin:
                                                                const EdgeInsets
                                                                        .fromLTRB(
                                                                    0, 0, 40, 0),
                                                            child: Text(
                                                                articleList[
                                                                        index]
                                                                    .comments
                                                                    .toString(),
                                                                style: const TextStyle(
                                                                    fontSize:
                                                                        10,
                                                                    color: Color
                                                                        .fromRGBO(
                                                                            44,
                                                                            58,
                                                                            75,
                                                                            1)))),
                                                        Image.asset(
                                                            'assets/images/save.png')
                                                      ],
                                                    )
                                                  ],
                                                ))),
                                      ],
                                    )));
                          }),
                    ),
                  ]);
                } else if (state is NewsErrorState) {
                  String error = state.errorMessage;
                  return Center(child: Text(error));
                } else {
                  return const Center(
                      child: CircularProgressIndicator(
                    backgroundColor: Colors.green,
                  ));
                }
              },
            ),
          )
        ],
      ),
    );
  }
}
