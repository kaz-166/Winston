## 1-1. 概要
## 
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
大数の弱法則によりサンプリングした平均値は真の平均値に収束するため下記が成り立つ。

$$\int_{a}^{b}f(x)dx \approx \cfrac{b - a}{N}\sum_{n=1}^{N}f(x^{(n)})$$

本プログラムでは疑似乱数を用いて上式を利用することにより定積分および広義積分を計算している。

## 2-4. 課題・将来要件など
### 2-3-1. 広義積分の計算時間
広義積分は多くの計算量を要する。パラメータを粗くとることで低減は可能であるが、精度とのトレードオフになる。
実動作ベースでは、広義積分の重積分が発生する多変数関数の分布における期待値や分散などの統計量の計算時間が現実的な時間とならない。
### 検討①
定積分は解析的に解けるものと解析的に解けないものに分類できるが、本プログラムではどちらも統一的に扱い2-2-1の計算方法により積分値を算出している。
解析的に解けるものについては初等関数が求まるため計算が簡易になる（すくなくとも近似計算よりは）ことが多い。継承先で個別に積分計算メソッドを定義し、
基底クラスメソッドをオーバーライドすることを検討するのも有用かもしれない。

### 検討②
テイラー級数近似を行い積分計算をすることも有用かもしれない。精度と計算時間については実験が必要

テイラー級数は多項式であらわされるため解析的な積分計算が容易である





