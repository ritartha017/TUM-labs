class ArticleModel {
  String? cover;
  String? title;
  String? category;
  Portal? portal;
  int? likes;
  int? comments;

  ArticleModel({
        this.cover,
        this.title,
        this.category,
        this.portal,
        this.likes,
        this.comments,
  });

  ArticleModel.fromJson(Map<String, dynamic> json) {
    portal = json['portal'] != null ? Portal.fromJson(json['portal']) : null;
    cover = json['cover'];
    title = json['title'];
    category = json['category'];
    likes = json['likes'];
    comments = json['comments'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    if (portal != null) data['portal'] = portal!.toJson();
    data['cover'] = cover;
    data['title'] = title;
    data['category'] = category;
    data['likes'] = likes;
    data['comments'] = comments;
    return data;
  }
}

class Portal {
  late String title;
  late String logo;

  Portal({required this.title, required this.logo});

  Portal.fromJson(Map<String, dynamic> json) {
    title = json['title'];
    logo = json['logo'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['title'] = title;
    data['logo'] = logo;
    return data;
  }
}