import './assets/css/styles.css';

declare var require: any

var React = require('react');
var ReactDOM = require('react-dom');

class Report extends React.Component {
    handleClick = () => {
        return "http://localhost:51601/report";
    }

    render() {
        return (
            <div class='body-style-center'>
                <a class='link-to-button' href={this.handleClick()}>Download excel file</a>
            </div>                
        );
    }
}

ReactDOM.render(<Report />, document.getElementById('root'));