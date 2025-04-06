## 1-1. 概要
本プログラムコードは筆者が「統計学入門(統計学入門Ⅰ)」(著：東京大学教養学部出版会)の理解を深める目的で作成されたものである。  　
https://www.amazon.co.jp/%E7%B5%B1%E8%A8%88%E5%AD%A6%E5%85%A5%E9%96%80-%E5%9F%BA%E7%A4%8E%E7%B5%B1%E8%A8%88%E5%AD%A6%E2%85%A0-%E6%9D%B1%E4%BA%AC%E5%A4%A7%E5%AD%A6%E6%95%99%E9%A4%8A%E5%AD%A6%E9%83%A8%E7%B5%B1%E8%A8%88%E5%AD%A6%E6%95%99%E5%AE%A4/dp/4130420658
## 2-1.フォルダ構成
### 2-1-1. distributions
確率分布クラスをまとめたフォルダ。continuousフォルダに連続型の確率分布クラス、discreteフォルダに離散型の確率分布クラスがまとめられている。分布の各論については2-2.を参照のこと。

それぞれの確率分布クラスは基底クラスを継承しており（連続型はContinuousDistributionBase、離散型はDiscreteDistributionBase）、
おのおのの基底クラスは抽象クラスAbstractDistributionを継承している。
### 2-1-2. extensions
拡張メソッドクラスをまとめたフォルダ。今回は階乗や順列、組み合わせなどの演算メソッドを拡張クラスとして実装している。

### 2-1-3. interfaces
インターフェースクラスをまとめたフォルダ。
本プログラムでは依存性逆転の原則(Depemdency Inversion Plinciple)の考え方に則り、積分計算クラスのインターフェースを用意し、依存性注入（DI）によりI/Fと実装を分離している。

## 2-2. 分布
本プログラムにて取り扱う分布を下記に示す。
### 2-2-1. 離散型
・二項分布(BinomialDistribution.cs)

$$f(x) = \cfrac{n!}{(n-x)!x!}p^{x}(1-p)^{n-x}$$

・ベルヌーイ分布(BernouliDistribution.cs)

$$f(x) = p^{x}(1-p)^{1-x}$$

・超幾何分布(HypergeometricDistribution.cs)
### 2-2-2. 連続型
・一様分布(UniformDistribution.cs)

$$f(x) = \cfrac{1}{b-a}$$

・指数分布(ExponentialDistribution.cs)

$$f(x) = \lambda e^{-\lambda x}$$

## 2-3. 特記事項
### 2-3-1. 積分計算について
本プログラムでは連続型関数の定積分は(a)台形近似と(b)モンテカルロ積分を用いて計算している。
### (a). 台形近似
台形近似は数値積分におけるポピュラーな積分近似の方法の一つである。

分割単位を $\Delta x$ とすると、積分区間 $[a, b]$ の定積分の近似式は下記で与えられる。

$$\int_{a}^{b}f(x)dx \approx \sum_{k=0}^{n-1}\cfrac{(f(k) + f(k + 1))\Delta x}{2}$$

また、広義積分については、十分に大きい値 $N$ を定義し、下記で示される式にて計算している。

$$\int_{-\infty}^{\infty}f(x)dx \approx \int_{-N}^{N}f(x)dx$$

### (b). モンテカルロ積分
モンテカルロ積分は乱択アルゴリズムであるモンテカルロ法を応用した積分近似の手法である。

$f(x)$ が区間 $[a,b]$ 一様分布 $p(x)$ に従う場合、

$$\int_{a}^{b}f(x)dx = \int_{a}^{b}\cfrac{f(x)p(x)}{p(x)}dx$$

$$= (b - a)\int_{a}^{b}f(x)p(x)dx$$

$$= (b - a)E(f(x))$$

と表せる。一様分布から抽出した値を $x^{(1)}, x^{(2)}, \dots x^{(N)}$ とすると、Nがじゅうぶんに大きい時、
大数の弱法則によりサンプリングした平均値は真の平均値に収束することが保証されるため下記が成り立つ。

$$\int_{a}^{b}f(x)dx \approx \cfrac{b - a}{N}\sum_{n=1}^{N}f(x^{(n)})$$

本プログラムでは疑似乱数を用いて上式を利用することにより定積分および広義積分を計算している。

## 3. 課題・将来要件など
### 3-1. 広義積分の計算時間
広義積分に限らず積分は必ずしも陽な形式で求まるとは限らない。その場合は近似する必要があるが、広義積分は無限を近似して扱うため非常に多くの計算量を要する。  
近似のパラメータを粗くとることで低減は可能であるが、精度とのトレードオフになる。
実動作ベースでは、広義積分の重積分が発生する多変数関数の分布における期待値や分散などの統計量の計算時間が現実的な時間とならないことが今回明らかになった。
### 検討①
定積分は解析的に解けるものと解析的に解けないものに分類できるが、本プログラムではどちらも統一的に扱い2-2-1の計算方法により積分値を算出している。
解析的に解けるものについては初等関数が求まるため計算が簡易になる（すくなくとも近似計算よりは）ことが多い。継承先で個別に積分計算メソッドを定義し、
基底クラスメソッドをオーバーライドすることを検討するのも有用かもしれない。

### 検討②
テイラー級数近似(マクローリン近似)を行い積分計算をすることも有用かもしれない。精度と計算時間については実験が必要

テイラー級数は多項式であらわされるため解析的な積分計算が容易である  
### Chat GPT回答
https://chatgpt.com/share/67f1d2b3-79cc-800f-8f8e-8c7444c4abad
## 4. 考察
## 4-1. 学習教材としての有用性
本プログラムの作成はソフトウェア開発及びオブジェクト指向言語やＣ＃という言語への理解を深めるための教材としても有用であったと考える。  
理由は、オブジェクト指向言語の特長である継承やポリモーフィズムといった機構を実際に使う場面が数多くあったためである。  
例えば、今回はオブジェクト指向の根底となる基底クラスの継承を行っている。  
また、インターフェースを作成し実装を分離させ、インターフェースと実装を分離させた。  
さらに、インターフェースを自体をメソッドに渡すＤＩ参照も行った(SOLID原則のうちの1つである依存性逆転の原則の適用)。    
Ｃ＃としては拡張メソッドの使用、ラムダ式の使用、ジェネリクスの使用といったやや高度なテクニックを要求される場面もあり、中級者以上のエンジニアへの学習教材としても適しているかもしれない。  
また数学的な素養は当然要求され、学部1年生レベルとはいえ広義積分や重積分の考え方は有していることが前提である。

## 答案 4章
# 4. 確率
## 4-1　ド・メレの問題
### i)
> さいころを4回投げるとき、下記のどちらに賭けた方が勝率が高いか？
> 
> (a) 6の目が少なくとも1回出る
> 
> (b) 6の目が1回も出ない

6の目が少なくとも一回出る確率は、
$$1-(\cfrac{5}{6})^4$$

$$= \cfrac{625}{1296} < \cfrac{1}{2}$$

よって１回も出ない方に賭ける方が勝率が高い。
  
**(答). "6の目が1回も出ない"に賭ける**
### ii)
> さいころを2個同時に24回投げるとき、下記のどちらに賭けた方が勝率が高いか？
> 
> (a) (6, 6)の目の組み合わせが少なくとも1回出る
> 
> (b) (6, 6)の目の組み合わせが1回も出ない

(6, 6)の目が少なくとも一回出る確率は

$$1-(\cfrac{35}{36})^{24}$$

$$= 0.491... < \cfrac{1}{2}$$

よって１回も出ない方に賭ける方が勝率が高い。
  
**(答). "(6, 6)の目の組み合わせが1回も出ない"に賭ける**

## 4-2　ホイヘンスの14の問題 第11
> 2個のさいころを何回投げればそのうちの1回は目の和が12になる確率が0.9を超えるか

さいころの目の和が12になる組み合わせは(6,6)の1通りのみである。よって、12になる確率が0.9を超える場合は下記の不等式が成り立つ。

$$1-(\cfrac{36-1}{36})^n > 0.9$$

上記の不等式を満たす最小の $n$ は82となる

**(答). 82回**
## 4-3 (標題なし)
> 30人の看護婦を15人ずつ2組の交代勤務に分ける分け方は何通りあるか

$$_nC_r (n=30, r=15)$$

$$=155117520$$   
  
**(答). 155117520通り**

(注記) 計算に使用したコードは下記
https://github.com/kaz-166/LearningStatistics/blob/692a377ca42b08ca6acda88c09bcf0b2d06b7ec1/LearningStatistics/calcs/Answer.cs#L7-L16
## 4-4　誕生日の問題
> r人の集団中に同じ誕生日の人が少なくとも2人ある確率は
> $$P_r = 1 - (1 - \cfrac{1}{365}) \cdot (1 - \cfrac{2}{365}) \cdot (1 -\cfrac{3}{365}) \dots (1 - \cfrac{(r - 1)}{365})$$
> であることを示せ。
> >  
> さらに、p = 5, 10, 15, 20～25, 30, 35, 40, 50, 60に対して $p_r$ を計算せよ。

$r$人の中で少なくとも１組以上同一の誕生日である組み合わせが存在する確率は  
$$P_r =1 - \cfrac{365!}{365^r \cdot (365 - r)!}$$
$$= 1 - (\cfrac{365}{365} \cdot \cfrac{364}{365} \cdot \cfrac{363}{365} \dots \cfrac{365 - r + 1}{365})$$
$$= 1 - (\cfrac{365}{365} \cdot \cfrac{365-1}{365} \cdot \cfrac{365-2}{365} \dots \cfrac{365 - (r - 1)}{365})$$
$$= 1 - (1 - \cfrac{1}{365}) \cdot (1 - \cfrac{2}{365}) \cdot (1 -\cfrac{3}{365}) \dots (1 - \cfrac{(r - 1)}{365})$$
よって、  
$$P_r = 1 - (1 - \cfrac{1}{365}) \cdot (1 - \cfrac{2}{365}) \cdot (1 -\cfrac{3}{365}) \dots (1 - \cfrac{(r - 1)}{365})$$ 
であることが示された。(証終)
## 4-5　行動科学と確率
> 心理学者が実験を行った。
> 
> ある大学の喫茶店には正方形のテーブルが配置されている。
> 
> 45組の学生客を観察したところ、隣り合って座る学生客は15組、向かい合って座る学生客は30組であった。
> 
> この結果から、心理学者は喫茶店の学生客は向かい合って座るより隣り合って座る方を好む性質があると結論付けた。
> 
> この心理学者の推論は妥当か？

正方形のテーブルに2組が座る場合の組み合わせは、4つの座席に2人を配置する問題と等価であるため、全部で6通りとなる。

また、そのうち隣り合って座る組み合わせは4通り、向かい合って座る組み合わせは2通りである。

座り方に嗜好性がない場合は、隣り合って座る確率は $2/3$ 、向かい合って座る確率は $1/3$ になる。

嗜好性があると仮定した場合、上記の確率とは外れた値になるはずであるが、実験結果は上記確率と一致する。

よって、背理法より心理学者の推論は妥当であるとは言えない。

**(答). 妥当ではない**

## 4-6　ガリレイの問題
> 3つのさいころを投げて目の和が9になる場合と10になる場合の目の組み合わせはいずれも6通りである。
>
> このとき、この2つの場合の起こる確率は等しいと言えるか？

目の和が9になる組み合わせは
$(1, 2, 6)$、
$(1, 3, 5)$、
$(1, 4, 4)$、
$(2, 2, 5)$、
$(2, 3, 4)$、
$(3, 3, 3)$
であり、それぞれ場合の数は6通り、6通り、3通り、3通り、6通り、1通りの計25通りであるため、目の和が9になる確率は
$\cfrac{25}{216}$
である。

一方で目の和が10になる組み合わせは
$(1, 3, 6)$、
$(1, 4, 5)$、
$(2, 2, 6)$、
$(2, 3, 5)$、
$(2, 4, 4)$、
$(3, 3, 4)$
であり、それぞれ場合の数は、6通り、6通り、3通り、6通り、3通り、3通りの計27通りであるため、目の和が10になる確率は
$\cfrac{1}{8}$
である。

よって、起こる確率は等しいとは言えない。

**(答). 等しいと言えない**
## 4-7　がんの診断
### i)
> がんを診断するための検査方法があるとする。
>
> $C$ を被検査者はがんであるという事象、 $A$ を検査の結果が被検査者ががんであると示す(検査結果が陽性となる)事象とする。
> 
>  $P(A | C) = 0.95$ 、 $P(A^c | C^c) = 0.95$ 、検査を受ける人の中で実際にがんである確率が $P(C | A) = 0.005$のとき、 $P(C | A)$ を求めよ。

まず、 $P(A^c \mid C)$ を求める。

$$P(C) = P(C \cap (A \cup A^c))$$
$$= P((C \cap A) \cup (C \cap A^c))$$
$$= P(C \cap A) + P(C \cap A^c)$$

乗法定理より、

$$= P(C) \cdot P(A \mid C) + P(C) \cdot P(A^c \mid C)$$

$$\iff P(A^c \mid C) = 1 - P(A \mid C)$$  

$P(A \mid C)=0.95$ より、

$$P(A^c \mid C) = 0.05$$

次に $P(A \mid C^c)$ を求める。

$$P(A \cap C) \cup P(A^c \cap C) \cup P(A \cap C^c) \cup P(A^c \cap C^c) = 1$$

$$\iff  P(C) \cdot P(A \mid C) + P(C) \cdot P(A^c \mid C) + P(C^c) \cdot P(A \mid C^c) + P(C^c) \cdot P(A^c \mid C^c) = 1$$

$P(C)=0.005$  、 $P(A^c \mid C^c)=0.95$ より、  
$$P(A \mid C^c) = 0.05$$  

ベイズの定理より、  
$$P(C|A) = \cfrac{P(C) \cdot P(A \mid C)}{P(C) \cdot P(A \mid C) + P(C^c) \cdot P(A \mid C^c)}$$
$$=0.087155...$$  

**(答). 0.087155**
### ii)
> i)において検査の信頼性が0.95ではなく、一般に $P(A | C) = P(A^c | C^c) = R (0 < R < 1)$ とした場合を考える。
> 
>  $P(C) = 0.005$ とするとき、 $P(C|A) \geq 0.90$ となるための $R$ の条件を求めよ。

$$P(C) \cdot R + P(C) \cdot (1 - R) + P(C^c) \cdot P(A \mid C^c) + P(C^c) \cdot R= 1$$

$$P(A \mid C^c) = \cfrac{1 - P(C) - R \cdot P(C^c)}{P(C^c)}$$

$$P(C|A) \ge 0.9$$

$$R \ge \cfrac{1791}{1792}= 0.999442...$$


## 答案 ５章
# 5. 確率変数
## 5-1
### i)
> [0, 6]上の一様分布の密度関数、期待値、分散を求めよ。

密度関数は、

$$
f(x) = \begin{cases}
    1/6 & (0 \leq x \leq 6) \\
    0 & otherwise
  \end{cases}
$$

期待値は、
$$E(x) = \int_{-\infty}^{\infty}xf(x)dx$$
$$= \cfrac{1}{6}\int_{0}^{6}xdx$$
$$= 3$$
分散は、
$$V(x) = E(x^2) - (E(x))^2$$
$$= \int_{-\infty}^{\infty}x^2f(x)dx - (\int_{-\infty}^{\infty}xf(x)dx)^2$$
$$= \cfrac{1}{6}\int_{0}^{6}x^2dx - (\cfrac{1}{6}\int_{0}^{6}xdx)^2$$
$$= 18 - 3^2$$
$$= 9$$
**(答). 密度関数： $f(x)=1/6 (0 \leq x \leq 6), 0 (x < 0, x > 6)$ 、期待値：3、分散：9**
### ii)
> [0, 6]上の一様分布に関して、チェビシェフの不等式が成立することを示せ。

$$P(|X - \mu| \geq k\sigma) = 1 - \int_{\mu - k\sigma}^{\mu + k\sigma}f(x)dx$$

$\mu = 3$ 、 ${\sigma}^2 = 9$ なので、 $k > 1$ のとき、

$$1 - \int_{\mu - k\sigma}^{\mu + k\sigma}f(x)dx = 1 - \int_{0}^{1}f(x)dx = 0 \leq \cfrac{1}{k^2} \cdots (1)$$

 $k \leq 1$ のとき、

 $$1 - \int_{\mu - k\sigma}^{\mu + k\sigma}f(x)dx = 1 - \cfrac{1}{6}(3(1 + k) - 3(1 - k)) = 1 - k$$

 ここで、 $g(x) = x^3 - x^2 +1$ を考える。 $\cfrac{dg(x)}{dx} = x(3x -2)$ なので、 $0 \leq x \leq 1$ において
 
 $$g(x) \geq g(\cfrac{2}{3}) = \cfrac{23}{27} \ge 0$$
 
 よって、

 $$\cfrac{1}{k^2} - (1 - k) = \cfrac{1}{k^2}g(k) \ge 0$$

 $$\iff 1 - k = 1 - \int_{\mu - k\sigma}^{\mu + k\sigma}f(x)dx \leq \cfrac{1}{k^2} \cdots (2)$$

 (1)、(2)より、すべての $k$ について

 $$P(|X - \mu| \geq k\sigma) \leq \cfrac{1}{k^2}$$

 が成立する。よってチェビシェフの不等式が成り立つことが示された。(証終)


### iii)
> [0, 1]上の一様分布に関して、歪度および突度を求めよ。

歪度は、

$$\cfrac{E((x - \mu)^3)}{\sigma^3} = \cfrac{1}{\sigma^3}(E(x^3) -3 \mu E(x^2) + 3 {\mu}^3 - \mu^3)$$

$$ 　　　　　　= \cfrac{1}{\sigma^3}(\int_{-\infty}^{\infty}x^3 f(x)dx -3 (\int_{-\infty}^{\infty}x f(x)dx) (\int_{-\infty}^{\infty}x^2 f(x)dx) + 2 (\int_{-\infty}^{\infty}x f(x)dx)^3)$$

$$ 　　= \cfrac{1}{\sigma^3}(\int_{0}^{1}x^3 dx -3 (\int_{0}^{1}x dx) (\int_{0}^{1}x^2 dx) + 2 (\int_{0}^{1}x dx)^3)$$

$$=0$$

突度は、

$$\alpha_4 = \cfrac{E((x - \mu)^4)}{\sigma^4} = \cfrac{1}{\sigma^4}(E(x^4) + 4 {\mu}^2 E(x^2) + {\mu}^4 - 4 \mu E(x^3) - 4 {\mu}^3 E(x) + 2 {\mu}^2 E(x^2))$$

$$ 　　　　= \cfrac{1}{\sigma^4}(\int_{0}^{1}x^4 dx + 6 (\int_{0}^{1}x dx)^2 \int_{0}^{1}x^2 dx - 4 (\int_{0}^{1}x dx) (\int_{0}^{1}x^3 dx) - 3 (\int_{0}^{1}x dx)^4)$$

$$= \cfrac{1}{80{\sigma}^2}$$

ここで、 ${\sigma} = \cfrac{1}{12}$ より、 $\alpha_4 = \cfrac{9}{5}$　。よって、 $\beta_4 = \alpha_4 - 3 = -\cfrac{6}{5}$

**(答). 歪度： $0$、突度： $-\cfrac{6}{5}$**

## 5-2
> 5.2節の宝くじの期待値を求めよ。

**(答). 89.4076...**

(注記) 計算に使用したコードは下記
https://github.com/kaz-166/LearningStatistics/blob/2a1aba2cf17e57e1ea5c34679c2680e1e9d4f7ce/LearningStatistics/calcs/Answer.cs#L19-L28
## 5-3 聖ペテルスブルグの逆説
> コインを繰り返し投げ、初めて表が出たときに止める。それが $n$ 回目であるとき、 $2^n$ 円を得るものとする。このとき、
> 
> i) 得られる額 $X$ の確率分布を求めよ
> 
> ii) $E(X)$ は存在しない(無限大に発散する)ことを示せ。

### i)
$n$ 回目で初めて表が出る確率は $\cfrac{1}{2^n}$ なので、得られる金額 $X$ の確率分布は

$$P(X = 2^n) = \cfrac{1}{2^n}$$

で表される。

### ii)
$$E(X) = \lim_{n\to \infty}\sum_{k = 1}^{n}\cfrac{1}{2^k} \cdot 2^k$$

$$= \lim_{n\to \infty}\sum_{k = 1}^{n}1$$

$$= 1 + 1 + 1 + \cdots$$

よって $E(X)$ は正の無限大に発散するため、存在しない。(証終)
## 5-4 最小平均二乗
> $E(X-a)^2$ を最小にする $a$ およびその最小値を求めよ。

$$E(X-a)^2 = E(X^2) - 2E(a)E(X) + (E(a))^2$$

$$= E(X^2) - 2aE(X) + a^2$$

$$= (a - E(X))^2$$

よって、 $a = E(X)$ の時に最小値0をとる。

**(答). $a = E(X)$ 、 最小値0**

## 5-5 
> 正 $n$ 面体で1, 2, ...,nの乱数を発生させるとする。このときの期待値と分散を求めよ。

期待値は、
$$E(X) = \sum_{k = 1}^{n}\cfrac{k}{n}$$

$$= \cfrac{n + 1}{2}$$

分散は、
$$V(X) = E(X^2) - (E(X))^2$$

$$= \sum_{k = 1}^{n}\cfrac{k^2}{n} - (\sum_{k = 1}^{n}\cfrac{k}{n})^2$$

$$= \cfrac{(n + 1)(2n + 1)}{6} - (\cfrac{n + 1}{2})^2$$

$$= \cfrac{n^2 - 1}{12}$$

**(答). 期待値： $\cfrac{n + 1}{2}$ 分散： $\cfrac{n^2 - 1}{12}$**

## 5-6 一様分布の平方変換
> 確率変数 $X$ が[0, 1]上の一様分布に従うとき、 $X^2$ の累積分布関数、密度関数、期待値、分散を求めよ。

累積分布関数は、

$$F_{X^2}(x) = P(X^2 \leq x) = \int_{-\infty}^{\sqrt{x}}f(x)dx = \int_{0}^{\sqrt{x}}dx = \sqrt{x}$$

$$F_{X^2}(x) = 0　　　　　(x \le 0)$$

$$F_{X^2}(x) = \sqrt{x}　(0 \leq x \leq 1)$$

$$F_{X^2}(x) = 1　　　　　(x \ge 1)$$

確率密度関数は、

$$f_{X^2}(x) = \frac{d}{dx}F_{X^2}(x) = \cfrac{d}{dx}\int_{-\infty}^{\sqrt{x}}f(x)dx = \cfrac{1}{2\sqrt{x}}$$

期待値は

$$E(X^2) = \int_{0}^{1}x^2f(x) = \cfrac{1}{3}$$

分散は

$$V(X^2) = E((X^2 - \mu)^2) = E(X^4) - (E(X^2))^2$$

$$= \int_{0}^{1}x^4dx - (\int_{0}^{1}x^2dx)^2 = \cfrac{4}{45}$$

## 5-7 正規分布の平方変換
> 確率変数 $X$ が[0, 1]上の正規分布に従うとき、 $X^2$ の累積分布関数、密度関数、期待値、分散を求めよ。

$$f(x) = N(1, 0) = \cfrac{1}{\sqrt{2\pi}}e^{-\cfrac{x^2}{2}}$$

$$F_{X^2}(x) = P(X^2 \leq x) = \cfrac{1}{\sqrt{2\pi}}\int_{-\sqrt{x}}^{\sqrt{x}}e^{-\cfrac{t^2}{2}}dt$$

$$= \cfrac{2}{\sqrt{2\pi}}(\int_{0}^{\sqrt{x}}t^{2}e^{-\cfrac{t^2}{2}})$$

$$= \cfrac{2}{\sqrt{2\pi}}(\int_{-\infty}^{\sqrt{x}}e^{-\cfrac{t^2}{2}}dt - \int_{-\infty}^{0}e^{-\cfrac{t^2}{2}}dt)$$

[0, 1]の正規分布の累積分布関数を $\varPhi(x)$ とすると、 $F_{X^2}(x) = 2(\varPhi(\sqrt{x}) - \cfrac{1}{2})$ と表せる。

密度関数は、

$$f_{X^2}(x) = \cfrac{d}{dx}F_{X^2}(x) = 2\cfrac{d}{dx}\int_{0}^{\sqrt{x}}e^{\cfrac{t^2}{2}}dt$$

ここで、 $\cfrac{d}{dx}\int_{0}^{\sqrt{x}}e^{\cfrac{t^2}{2}}dt$ の原始関数を $G(x)$ とおくと、

$$\cfrac{d}{dx}\int_{0}^{\sqrt{x}}e^{\cfrac{t^2}{2}}dt = G(\sqrt{x}) - G(0)$$

$$2\cfrac{d}{dx}\int_{0}^{\sqrt{x}}e^{\cfrac{t^2}{2}}dt = 2e^{-\cfrac{x^2}{2}}\cfrac{d(\sqrt{x})}{dx}$$

$$= \cfrac{1}{\sqrt{2 \pi x}} e^{-\cfrac{x^2}{2}}$$

期待値は、

$$E(X^2) = \cfrac{1}{\sqrt{2\pi}}\int_{-\infty}^{\infty}x^2e^{-\cfrac{x^2}{2}}dx$$

$$= -\cfrac{1}{\sqrt{2\pi}}\int_{-\infty}^{\infty}x\cfrac{d}{dx}e^{-\cfrac{x^2}{2}}dx$$

$$= \cfrac{1}{\sqrt{2\pi}}\int_{-\infty}^{\infty}e^{-\cfrac{x^2}{2}}dx$$

$$= 1$$

分散は、

$$X(X^2) = E(X^4) - (E(X^2))^2$$ 

ここで、

$$E(X^4) = \cfrac{1}{\sqrt{2\pi}}\int_{-\infty}^{\infty}x^4e^{-\cfrac{x^2}{2}}dx$$

$$= -\cfrac{1}{\sqrt{2\pi}}\int_{-\infty}^{\infty}x^3\cfrac{d}{dx}e^{-\cfrac{x^2}{2}}dx$$

$$= \cfrac{3}{\sqrt{2\pi}}\int_{-\infty}^{\infty}x^2e^{-\cfrac{x^2}{2}}dx$$

$$= 3$$

よって、

$$V(Y^2) = 2$$




