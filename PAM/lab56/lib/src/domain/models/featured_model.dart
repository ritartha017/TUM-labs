class FeaturedModel {
  String? cover;
  String? title;

  FeaturedModel({
    this.cover,
    this.title,
  });

  FeaturedModel.fromJson(Map<String, dynamic> json) {
    cover = json['cover'];
    title = json['title'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['cover'] = cover;
    data['title'] = title;
    return data;
  }
}
