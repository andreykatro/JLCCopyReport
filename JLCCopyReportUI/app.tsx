declare var require: any

var React = require('react');
var ReactDOM = require('react-dom');

class Report extends React.Component {
    handleClick = () => {
        //alert("Hello !!!");
        return "http://localhost:51601/report";
    }

    render() {
        return (
            <a href={this.handleClick()} class="button">Download excel file</a>
        );
    }
}

ReactDOM.render(<Report />, document.getElementById('root'));