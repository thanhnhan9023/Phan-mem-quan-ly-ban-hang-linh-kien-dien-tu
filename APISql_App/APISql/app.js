'use strict';

const port = 3000;

var express = require('express')
var bodyParser = require('body-parser')
var app = express();
var routes = require('./routes/index');

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));

app.use('/', routes);// test api





app.listen(port, () => { console.log("Api runing") });