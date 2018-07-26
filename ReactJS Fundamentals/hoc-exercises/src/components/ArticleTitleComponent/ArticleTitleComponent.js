import React from "react";
import withWarning from "../hoc/withWarning";

class ArticleTitleBase extends React.Component {

  render() {
    return (
        <article>
          <header>
            <span className="title">Article Title</span>
          </header>
          <p>
            Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet magni
            labore voluptatibus. Vel sunt voluptate fugiat et ducimus voluptates
            doloremque, eum illo exercitationem dignissimos sequi cum, id
            molestiae debitis atque.
          </p>
        </article>
    );
  }
}

const ArticleTitle = withWarning(ArticleTitleBase);

export default ArticleTitle;
