using System.Linq;
using FluentAssertions;
using Richargh.BillionDollar.Classic;
using Xunit;

namespace Richargh.BillionDollar.Test
{
    public class InventoryTest
    {
        [Fact(DisplayName="Should find nothing when Repository is empty")]
        public void ShouldFindNothing()
        {
            // given
            var testee = new Inventory();
            // when
            var result = testee.FindNotebookById(new NotebookId("1"));
            // then
            result.Should().BeNull();
        }
        
        [Fact(DisplayName="Should find notebook after we've put it into the Repository")]
        public void ShouldFindNotebookAfterPut()
        {
            // given
            var notebook = new Notebook(new NotebookId("1"), NotebookType.Performance, "Bell", "GT Banana");
            var testee = new Inventory();
            testee.Put(notebook);
            // when
            var result = testee.FindNotebookById(notebook.Id);
            // then
            result.Should().BeEquivalentTo(notebook);
        }
        
        [Fact(DisplayName="Should find employee when already in the Repository")]
        public void ShouldFindAlreadyKnownEmployee()
        {
            // given
            var notebook = new Notebook(new NotebookId("1"), NotebookType.Performance, "Bell", "GT Banana");
            var testee = new Inventory(notebook);
            // when
            var result = testee.FindNotebookById(notebook.Id);
            // then
            result.Should().BeEquivalentTo(notebook);
        }
        
        [Fact(DisplayName="Should find notebook by its type")]
        public void ShouldFindNotebookByType()
        {
            // given
            var performance = new Notebook(new NotebookId("1"), NotebookType.Performance, "Bell", "GT Banana");
            var office = new Notebook(new NotebookId("2"), NotebookType.Office, "Bell", "M Cherry");
            var testee = new Inventory();
            testee.Put(performance);
            testee.Put(office);
            // when
            var result = testee.FindNotebooksByType(NotebookType.Performance);
            // then
            result.Single().Should().BeEquivalentTo(performance);
        }
    }
}