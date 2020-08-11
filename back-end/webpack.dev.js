/// <binding />
"use strict";

var path = require('path');
var webpack = require('webpack');
var ExtractTextPlugin = require("extract-text-webpack-plugin");
var ForkTsCheckerWebpackPlugin = require('fork-ts-checker-webpack-plugin');
var HtmlWebpackPlugin = require('html-webpack-plugin');
var BundleAnalyzerPlugin = require('webpack-bundle-analyzer').BundleAnalyzerPlugin;

const handler = (percentage, message, ...args) => {
    console.info(percentage, message, ...args);
};

module.exports = {
    mode: 'development',
    devtool: 'source-map',
    entry: {
        index: "./app/appStart.tsx"
    },
    output: {
        filename: "[name].[hash].js",
        chunkFilename: '[name].[hash].bundle.js',
        path: path.resolve(__dirname, 'public/dist')
    },
    devServer: {
        contentBase: './',
        host: "localhost",
        port: 9000,
        index: 'app.html'
    },
    resolve: {
        extensions: ['.ts', '.tsx', '.js', ".jsx"],
        modules: ["node_modules", path.resolve(__dirname, "app")]
    },
    module: {
        rules:
            [
                {
                    test: [/\.scss$/, /\.css$/],
                    use: ExtractTextPlugin.extract({
                        use: [{
                            loader: "css-loader"
                        }, {
                            loader: "sass-loader"
                        }]
                    })
                },
                {
                    test: /\.ts(x?)$/,
                    loader: 'ts-loader',
                    options: {
                        transpileOnly: true
                    },
                    exclude: /(node_modules)/
                },
                {
                    test: /\.(mov|mp4)$/,
                    use: [
                        {
                            loader: 'file-loader',
                            options: {
                                name: '[path].[name].[ext]'
                            }
                        }
                    ]
                },
                {
                    test: /\.(jpe?g|gif|png)$/,
                    loader: 'file-loader?emitFile=false&name=[path][name].[ext]'
                },
                {
                    test: /\.(eot|svg|ttf|woff|woff2|otf)$/,
                    use: 'file-loader?name=/fonts/[name].[ext]'
                },
                {
                    test: /\.svg$/,
                    use: 'svg-react'
                }
            ]
    },
    optimization: {
        runtimeChunk: 'single',
        splitChunks: {
            chunks: 'all',
            maxInitialRequests: Infinity,
            minSize: 0,
            cacheGroups: {
                vendor: {
                    test: /[\\/]node_modules[\\/]/,
                    name(module) {
                        const packageName = module.context.match(/[\\/]node_modules[\\/](.*?)([\\/]|$)/)[1];

                        if (packageName == 'devextreme') {
                            return `${packageName.replace('@', '')}`;
                        }
                        else if (packageName.toUpperCase().indexOf('REACT') !== -1) {
                            return `react`;
                        }

                        else if (packageName.toUpperCase().indexOf('MATERIAL') !== -1) {
                            return `material`;
                        }

                        else return "vendor";
                    },
                },
            },
        }
    },
    plugins: [
        new BundleAnalyzerPlugin(),
        new HtmlWebpackPlugin({
            template: "template.ejs",
            filename: 'app.html',
            path: path.resolve(__dirname, 'public/dist'),
        }),
        new webpack.EnvironmentPlugin(),
        new ExtractTextPlugin('styles.css'),
        new ForkTsCheckerWebpackPlugin(
            {
                memoryLimit: 200048
            }
        ),
        new webpack.IgnorePlugin({
            resourceRegExp: /^\.\/locale$/,
            contextRegExp: /moment$/
        }),
        new webpack.ProgressPlugin(handler)
    ]
};
