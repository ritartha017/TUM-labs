import 'package:flutter/material.dart';
import 'package:cached_network_image/cached_network_image.dart';
import 'package:lab5/src/presentation/blocs/newsbloc/news_bloc.dart';
import 'package:lab5/src/presentation/blocs/newsbloc/news_states.dart';
import 'package:lab5/src/domain/models/article_model.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:lab5/src/domain/models/featured_model.dart';
import 'package:lab5/src/data/api_requests.dart';

class ArticleScreen extends StatefulWidget {
  ArticleScreen({Key? key}) : super(key: key);

  @override
  State<ArticleScreen> createState() => _ArticleScreenState();
}

class _ArticleScreenState extends State<ArticleScreen> {
  @override
  Widget build(BuildContext context) {
    var height = MediaQuery.of(context).size.height;
    var data = ModalRoute.of(context)?.settings.arguments as Map;

    return Scaffold(
      body: Stack(
        children: [
          Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Container(
                margin: const EdgeInsets.fromLTRB(16, 45, 16, 16),
                child: const Text(
                  "<-",
                  style: TextStyle(
                    fontSize: 20,
                    fontWeight: FontWeight.bold,
                    color: Color(0xFFFF6861),
                  ),
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
                    Container(
                        margin: const EdgeInsets.fromLTRB(17, 10, 15, 0),
                        child: Stack(children: <Widget>[
                          ClipRRect(
                            borderRadius: BorderRadius.circular(20),
                            child: CachedNetworkImage(
                                imageUrl: data["cover"].toString(),
                                height: 252,
                                width: 358,
                                fit: BoxFit.fill),
                          ),
                        ])),
                    Expanded(
                        child: Container(
                            margin: const EdgeInsets.fromLTRB(17, 0, 16, 0),
                            child: Row(
                              mainAxisAlignment: MainAxisAlignment.start,
                              children: <Widget>[
                                Flexible(
                                    child: Container(
                                        margin: const EdgeInsets.fromLTRB(
                                            0, 16, 0, 0),
                                        child: Column(
                                          children: <Widget>[
                                            Text(
                                              data["title"].toString(),
                                              overflow: TextOverflow.ellipsis,
                                              maxLines: 2,
                                              style: const TextStyle(
                                                  fontSize: 18,
                                                  fontWeight: FontWeight.bold,
                                                  color: Color(0xFF2C3A4B)),
                                            ),
                                            //politic, views, likes, comments
                                            Container(
                                              margin: const EdgeInsets.fromLTRB(
                                                  0, 18, 0, 0),
                                              child: Row(
                                                children: <Widget>[
                                                  Container(
                                                    padding: const EdgeInsets
                                                        .fromLTRB(8, 2, 8, 2),
                                                    decoration: BoxDecoration(
                                                      border: Border.all(
                                                        color:
                                                            Color(0xFFFF6861),
                                                      ),
                                                      borderRadius:
                                                          const BorderRadius
                                                                  .all(
                                                              Radius.circular(
                                                                  18) //                 <--- border radius here
                                                              ),
                                                    ),
                                                    child: Text(
                                                      articleList[1].category ??
                                                          "",
                                                      style: const TextStyle(
                                                          fontWeight:
                                                              FontWeight.bold,
                                                          fontSize: 10,
                                                          color: Color.fromRGBO(
                                                              255, 104, 97, 1)),
                                                    ),
                                                  ),
                                                  Container(
                                                      margin: const EdgeInsets
                                                              .fromLTRB(
                                                          20, 0, 0, 0),
                                                      child: Image.asset(
                                                          'assets/images/Views.png',
                                                          height: 16,
                                                          width: 16)),
                                                  Container(
                                                      margin: const EdgeInsets
                                                          .fromLTRB(5, 0, 0, 0),
                                                      child: FutureBuilder<Article>(
                                                        future: fetchArticle(data["article_index"] + 1),
                                                        builder: (context, snapshot) {
                                                          if (snapshot.hasData) {
                                                            return Text(
                                                              snapshot.data!.views_count.toString(),
                                                              overflow:
                                                              TextOverflow.ellipsis,
                                                              textAlign:
                                                              TextAlign.justify,
                                                              maxLines: 50,
                                                              style: const TextStyle(
                                                                fontSize: 10,
                                                                fontWeight:
                                                                FontWeight.bold,
                                                              ),
                                                            );
                                                          } else if (snapshot
                                                              .hasError) {
                                                            return Text("Error");
                                                          }
                                                          return const CircularProgressIndicator();
                                                        },
                                                      )),
                                                  Container(
                                                      margin: const EdgeInsets
                                                              .fromLTRB(
                                                          20, 0, 0, 0),
                                                      child: Image.asset(
                                                          'assets/images/Likes.png',
                                                          height: 16,
                                                          width: 16)),
                                                  Container(
                                                      margin: const EdgeInsets
                                                          .fromLTRB(5, 0, 0, 0),
                                                      child: Text(
                                                          articleList[1]
                                                              .likes
                                                              .toString(),
                                                          style:
                                                              const TextStyle(
                                                            fontSize: 10,
                                                            fontWeight:
                                                                FontWeight.bold,
                                                          ))),
                                                  Container(
                                                      margin: const EdgeInsets
                                                              .fromLTRB(
                                                          20, 0, 0, 0),
                                                      child: Image.asset(
                                                          'assets/images/Comments.png',
                                                          height: 16,
                                                          width: 16)),
                                                  Container(
                                                      margin: const EdgeInsets
                                                          .fromLTRB(5, 0, 0, 0),
                                                      child: Text(
                                                          articleList[1]
                                                              .comments
                                                              .toString(),
                                                          style:
                                                              const TextStyle(
                                                            fontSize: 10,
                                                            fontWeight:
                                                                FontWeight.bold,
                                                          ))),
                                                ],
                                              ),
                                            ),
                                            //logo, +follow
                                            Container(
                                              margin: const EdgeInsets.fromLTRB(
                                                  0, 22, 0, 0),
                                            ),
                                            Row(
                                              children: <Widget>[
                                                Container(
                                                  child: ClipRRect(
                                                    borderRadius:
                                                        BorderRadius.circular(
                                                            50),
                                                    child: Image.network(
                                                        articleList[1]
                                                            .portal!
                                                            .logo,
                                                        width: 32,
                                                        height: 32,
                                                        fit: BoxFit.cover),
                                                  ),
                                                ),
                                                Container(
                                                  margin:
                                                      const EdgeInsets.fromLTRB(
                                                          8, 0, 0, 0),
                                                  child: Text(
                                                    articleList[1]
                                                        .portal!
                                                        .title,
                                                    style: const TextStyle(
                                                      fontWeight:
                                                          FontWeight.bold,
                                                      fontSize: 10,
                                                      color: Color(0xFFFF6861),
                                                    ),
                                                  ),
                                                ),
                                                Container(
                                                  margin:
                                                      const EdgeInsets.fromLTRB(
                                                          200, 0, 0, 0),
                                                  width: 85,
                                                  height: 32,
                                                  padding:
                                                      const EdgeInsets.fromLTRB(
                                                          12, 8, 12, 8),
                                                  decoration:
                                                      const BoxDecoration(
                                                    color: Color(0xFFFF6861),
                                                    borderRadius:
                                                        BorderRadius.all(
                                                      Radius.circular(24),
                                                    ),
                                                  ),
                                                  child: const Text(
                                                    '+ Follow',
                                                    style: TextStyle(
                                                        fontSize: 14,
                                                        color: Colors.white),
                                                  ),
                                                ),
                                              ],
                                            ),
                                            Container(
                                              margin: const EdgeInsets.fromLTRB(
                                                  0, 16, 0, 0),
                                              child: FutureBuilder<Article>(
                                                future: fetchArticle(data["article_index"] + 1),
                                                builder: (context, snapshot) {
                                                  if (snapshot.hasData) {
                                                    return Text(
                                                      snapshot.data!.content,
                                                      overflow:
                                                          TextOverflow.ellipsis,
                                                      textAlign:
                                                          TextAlign.justify,
                                                      maxLines: 50,
                                                      style: const TextStyle(
                                                          fontSize: 12,
                                                          color: Color(
                                                              0xFF2C3A4B)),
                                                    );
                                                  } else if (snapshot
                                                      .hasError) {
                                                    return Text("Error");
                                                  }
                                                  return const CircularProgressIndicator();
                                                },
                                              ),
                                            ),
                                          ],
                                        ))),
                              ],
                            ))),
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
