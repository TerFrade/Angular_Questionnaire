const webpack = require('webpack');
const path = require('path');
const CheckerPlugin = require('awesome-typescript-loader').CheckerPlugin;
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const UglifyJsPlugin = require('uglifyjs-webpack-plugin');
const OptimizeCSSAssetsPlugin = require('optimize-css-assets-webpack-plugin');

const dir = __dirname;
const srcDir = path.join(dir, './src');
const clientBundleOutputDir = './www';

module.exports = (env) => {
   const isDevBuild = !(env && env.prod);
   return {
      context: srcDir,
      mode: isDevBuild ? 'development' : 'production',
      entry: './main',
      resolve: { extensions: ['.js', '.ts', '.json', '.css'] },
      output: {
         path: path.join(dir, clientBundleOutputDir),
         filename: 'main.js',
         publicPath: '/'
      },
      module: {
         rules: [
            { test: /\.ts$/, loader: 'awesome-typescript-loader?silent=true' },
            { test: /\.html$/, loader: 'html-loader?minimize=false' },
            { test: /\.css$/,
              rules: [
                { include: /\.component\.css$/, use: ['css-loader'] },
                { exclude: /\.component\.css$/, use: [MiniCssExtractPlugin.loader, 'css-loader'] }
              ] 
            },
            { test: /\.(png|jpg|jpeg|gif|svg|eot|woff2?|ttf)$/, loader: 'url-loader?limit=25000' }
         ]
      },
      plugins: [
         new MiniCssExtractPlugin({ filename: '[name].css' }),
         new CheckerPlugin(),
         new webpack.DefinePlugin({
            IS_DEV_BUILD: isDevBuild ? 'true': 'false',
            API_URL_GLOBAL: isDevBuild ? "'http://localhost:51465/api/'" : "'/api/'",
            OAUTH_URL_GLOBAL: isDevBuild ? "'http://localhost:1338/token'" : "'/token'",
            FRONT_URL_GLOBAL: isDevBuild ? "'http://localhost:4200/'" : "'/'",
         })
      ].concat(isDevBuild ? [
         new webpack.SourceMapDevToolPlugin({
            filename: '[file].map',
            moduleFilenameTemplate: path.relative(clientBundleOutputDir, '[resourcePath]') 
         })
      ] : [
      ]),
      optimization: {
         minimizer: isDevBuild ? undefined : [
            new UglifyJsPlugin({ cache: true, parallel: true, sourceMap: false }),
            new OptimizeCSSAssetsPlugin({})
         ],
         splitChunks: {
            cacheGroups: {
               styles: {
                  name: 'styles',
                  test: /\.css$/,
                  chunks: 'all',
                  enforce: true
               }
            }
         }
      }
   };
};
