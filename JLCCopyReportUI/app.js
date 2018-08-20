"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
require("./app.css");
var React = require('react');
var ReactDOM = require('react-dom');
var Report = /** @class */ (function (_super) {
    __extends(Report, _super);
    function Report() {
        var _this = _super !== null && _super.apply(this, arguments) || this;
        _this.handleClick = function () {
            return "http://localhost:51601/report";
        };
        return _this;
    }
    Report.prototype.render = function () {
        return (React.createElement("a", { href: this.handleClick() }, "Download excel file"));
    };
    return Report;
}(React.Component));
ReactDOM.render(React.createElement(Report, null), document.getElementById('root'));
//# sourceMappingURL=app.js.map