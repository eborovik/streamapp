import React, { Component } from 'react';
import { SavedVideo } from './SavedVideo';
import { getLiveVideos } from "../actions/Videos";
import { connect } from 'react-redux';
import { withRouter } from 'react-router-dom';

class Records extends Component {
    static displayName = Records.name;

    constructor(props) {
        super(props);
        this.state = { data: [] };

        this.fetchVideos = this.fetchVideos.bind(this);
        this.createItemList.bind(this)
    }

    componentDidMount() {
        this.fetchVideos();
    }

    fetchVideos = () => {
        this.setState({ ...this.state, isFetching: true });
        this.props.getLiveVideos()
            .then(response => {
                this.setState({ data: response.data, isFetching: false })
                console.log(response.data)
            })
            .catch(e => {
                console.log(e);
                this.setState({ ...this.state, isFetching: false });
            });
    };

    createItemList() {
        let rows = {}
        let counter = 1
        this.state.data.forEach((item, idx) => {
            rows[counter] = rows[counter] ? [...rows[counter]] : []
            if (idx % 4 === 0 && idx !== 0) {
                counter++
                rows[counter] = rows[counter] ? [...rows[counter]] : []
                rows[counter].push(item)
            } else {
                rows[counter].push(item)
            }
        })
        return rows
    }


    render() {

        let rows = this.createItemList()

        return (
            <section className="section items">
                <div className="container">
                    {Object.keys(rows).map(row => {
                        return (
                            <div className="row items__row" key={row}>
                                {rows[row].map(item => {
                                    return <SavedVideo {...item} />;
                                })}
                            </div>
                        )
                    })}
                </div>
            </section>
        )
    }
}

export default withRouter(connect(null, { getLiveVideos })(Records));