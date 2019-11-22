//const gulp = require("gulp");
const webpack = require("webpack");
//const path = require("path");
//const fs = require("fs");
const argv = require("yargs").argv;

function onBuild(done) {
    return function (err, stats) {
        if (err || stats.hasErrors()) {
            if (done) {
                done(err || stats);
            } else {
                console.log("Error", err);
            }
        } else {
            console.log(stats.toString());
            if (done) {
                done();
            }
        }
    };
}

const WebpackDevServer = require("webpack-dev-server");
const OpenBrowserPlugin = require("open-browser-webpack-plugin");
const clientConfig = require("./webpack.config.js")(argv);
const isDevBuild = !(argv && argv.prod);
const port = argv.port || 4200;
const url = "http://localhost:" + port;
clientConfig.plugins.push(new OpenBrowserPlugin({ url: url }));
const server = new WebpackDevServer(webpack(clientConfig), {
    contentBase: clientConfig.output.path,
    filename: clientConfig.output.filename,
    publicPath: clientConfig.output.publicPath,
    stats: { colors: true },
    watchOptions: { aggregateTimeout: 1000 },
    hot: isDevBuild,
    lazy: false,
    quiet: false,
    noInfo: false,
    historyApiFallback: true
});
server.listen(port, function (err) {
    console.log("Starting server on http://localhost:4200");
    if (err) {
        console.log("Error", err);
    }
});